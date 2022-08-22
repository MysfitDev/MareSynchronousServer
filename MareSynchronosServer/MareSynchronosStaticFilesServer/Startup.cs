using MareSynchronosShared.Authentication;
using MareSynchronosShared.Data;
using MareSynchronosShared.Models;
using MareSynchronosShared.Protos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace MareSynchronosStaticFilesServer;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddTransient(_ => Configuration);

        services.AddGrpcClient<AuthService.AuthServiceClient>(c =>
        {
            c.Address = new Uri(Configuration.GetValue<string>("ServiceAddress"));
        });

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = SecretKeyGrpcAuthenticationHandler.AuthScheme;
            })
            .AddScheme<AuthenticationSchemeOptions, SecretKeyGrpcAuthenticationHandler>(SecretKeyGrpcAuthenticationHandler.AuthScheme, options => { });
        services.AddAuthorization(options => options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseStaticFiles();
        app.UseHttpLogging();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(Configuration["CacheDirectory"]),
            RequestPath = "/cache",
            ServeUnknownFileTypes = true
        });
    }
}