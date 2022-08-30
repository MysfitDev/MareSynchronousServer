﻿// <auto-generated />
using System;
using MareSynchronosShared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MareSynchronosServer.Migrations
{
    [DbContext(typeof(MareDbContext))]
    [Migration("20220824225157_AddAlias")]
    partial class AddAlias
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MareSynchronosShared.Models.Auth", b =>
                {
                    b.Property<string>("HashedKey")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("hashed_key");

                    b.Property<string>("UserUID")
                        .HasColumnType("character varying(10)")
                        .HasColumnName("user_uid");

                    b.HasKey("HashedKey")
                        .HasName("pk_auth");

                    b.HasIndex("UserUID")
                        .HasDatabaseName("ix_auth_user_uid");

                    b.ToTable("auth", (string)null);
                });

            modelBuilder.Entity("MareSynchronosShared.Models.Banned", b =>
                {
                    b.Property<string>("CharacterIdentification")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("character_identification");

                    b.Property<string>("Reason")
                        .HasColumnType("text")
                        .HasColumnName("reason");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("timestamp");

                    b.HasKey("CharacterIdentification")
                        .HasName("pk_banned_users");

                    b.ToTable("banned_users", (string)null);
                });

            modelBuilder.Entity("MareSynchronosShared.Models.BannedRegistrations", b =>
                {
                    b.Property<string>("DiscordIdOrLodestoneAuth")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("discord_id_or_lodestone_auth");

                    b.HasKey("DiscordIdOrLodestoneAuth")
                        .HasName("pk_banned_registrations");

                    b.ToTable("banned_registrations", (string)null);
                });

            modelBuilder.Entity("MareSynchronosShared.Models.ClientPair", b =>
                {
                    b.Property<string>("UserUID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("user_uid");

                    b.Property<string>("OtherUserUID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("other_user_uid");

                    b.Property<bool>("AllowReceivingMessages")
                        .HasColumnType("boolean")
                        .HasColumnName("allow_receiving_messages");

                    b.Property<bool>("IsPaused")
                        .HasColumnType("boolean")
                        .HasColumnName("is_paused");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("timestamp");

                    b.HasKey("UserUID", "OtherUserUID")
                        .HasName("pk_client_pairs");

                    b.HasIndex("OtherUserUID")
                        .HasDatabaseName("ix_client_pairs_other_user_uid");

                    b.HasIndex("UserUID")
                        .HasDatabaseName("ix_client_pairs_user_uid");

                    b.ToTable("client_pairs", (string)null);
                });

            modelBuilder.Entity("MareSynchronosShared.Models.FileCache", b =>
                {
                    b.Property<string>("Hash")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("hash");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("timestamp");

                    b.Property<bool>("Uploaded")
                        .HasColumnType("boolean")
                        .HasColumnName("uploaded");

                    b.Property<string>("UploaderUID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("uploader_uid");

                    b.HasKey("Hash")
                        .HasName("pk_file_caches");

                    b.HasIndex("UploaderUID")
                        .HasDatabaseName("ix_file_caches_uploader_uid");

                    b.ToTable("file_caches", (string)null);
                });

            modelBuilder.Entity("MareSynchronosShared.Models.ForbiddenUploadEntry", b =>
                {
                    b.Property<string>("Hash")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("hash");

                    b.Property<string>("ForbiddenBy")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("forbidden_by");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("timestamp");

                    b.HasKey("Hash")
                        .HasName("pk_forbidden_upload_entries");

                    b.ToTable("forbidden_upload_entries", (string)null);
                });

            modelBuilder.Entity("MareSynchronosShared.Models.LodeStoneAuth", b =>
                {
                    b.Property<decimal>("DiscordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("discord_id");

                    b.Property<string>("HashedLodestoneId")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("hashed_lodestone_id");

                    b.Property<string>("LodestoneAuthString")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("lodestone_auth_string");

                    b.Property<DateTime?>("StartedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("started_at");

                    b.Property<string>("UserUID")
                        .HasColumnType("character varying(10)")
                        .HasColumnName("user_uid");

                    b.HasKey("DiscordId")
                        .HasName("pk_lodestone_auth");

                    b.HasIndex("UserUID")
                        .HasDatabaseName("ix_lodestone_auth_user_uid");

                    b.ToTable("lodestone_auth", (string)null);
                });

            modelBuilder.Entity("MareSynchronosShared.Models.User", b =>
                {
                    b.Property<string>("UID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("uid");

                    b.Property<string>("Alias")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("alias");

                    b.Property<string>("CharacterIdentification")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("character_identification");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean")
                        .HasColumnName("is_admin");

                    b.Property<bool>("IsModerator")
                        .HasColumnType("boolean")
                        .HasColumnName("is_moderator");

                    b.Property<DateTime>("LastLoggedIn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_logged_in");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea")
                        .HasColumnName("timestamp");

                    b.HasKey("UID")
                        .HasName("pk_users");

                    b.HasIndex("CharacterIdentification")
                        .HasDatabaseName("ix_users_character_identification");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("MareSynchronosShared.Models.Auth", b =>
                {
                    b.HasOne("MareSynchronosShared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUID")
                        .HasConstraintName("fk_auth_users_user_temp_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MareSynchronosShared.Models.ClientPair", b =>
                {
                    b.HasOne("MareSynchronosShared.Models.User", "OtherUser")
                        .WithMany()
                        .HasForeignKey("OtherUserUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_client_pairs_users_other_user_temp_id1");

                    b.HasOne("MareSynchronosShared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_client_pairs_users_user_temp_id2");

                    b.Navigation("OtherUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MareSynchronosShared.Models.FileCache", b =>
                {
                    b.HasOne("MareSynchronosShared.Models.User", "Uploader")
                        .WithMany()
                        .HasForeignKey("UploaderUID")
                        .HasConstraintName("fk_file_caches_users_uploader_uid");

                    b.Navigation("Uploader");
                });

            modelBuilder.Entity("MareSynchronosShared.Models.LodeStoneAuth", b =>
                {
                    b.HasOne("MareSynchronosShared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUID")
                        .HasConstraintName("fk_lodestone_auth_users_user_uid");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}