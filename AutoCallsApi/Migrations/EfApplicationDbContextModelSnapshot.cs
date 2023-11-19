﻿// <auto-generated />
using System;
using AutoCallsApi.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoCallsApi.Migrations
{
    [DbContext(typeof(EfApplicationDbContext))]
    partial class EfApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutoCallsApi.Models.Audio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AudioUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Audios");
                });

            modelBuilder.Entity("AutoCallsApi.Models.Call", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AudioId")
                        .HasColumnType("integer");

                    b.Property<int?>("MasiveCallId")
                        .HasColumnType("integer");

                    b.Property<int>("NumberId")
                        .HasColumnType("integer");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AudioId")
                        .IsUnique();

                    b.HasIndex("MasiveCallId");

                    b.HasIndex("NumberId")
                        .IsUnique();

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("AutoCallsApi.Models.MasiveCall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AudioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AudioId")
                        .IsUnique();

                    b.ToTable("MasiveCalls");
                });

            modelBuilder.Entity("AutoCallsApi.Models.Number", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NumberValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Numbers");
                });

            modelBuilder.Entity("AutoCallsApi.Models.Call", b =>
                {
                    b.HasOne("AutoCallsApi.Models.Audio", "Audio")
                        .WithOne()
                        .HasForeignKey("AutoCallsApi.Models.Call", "AudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoCallsApi.Models.MasiveCall", null)
                        .WithMany("Calls")
                        .HasForeignKey("MasiveCallId");

                    b.HasOne("AutoCallsApi.Models.Number", "Number")
                        .WithOne()
                        .HasForeignKey("AutoCallsApi.Models.Call", "NumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audio");

                    b.Navigation("Number");
                });

            modelBuilder.Entity("AutoCallsApi.Models.MasiveCall", b =>
                {
                    b.HasOne("AutoCallsApi.Models.Audio", "Audio")
                        .WithOne()
                        .HasForeignKey("AutoCallsApi.Models.MasiveCall", "AudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audio");
                });

            modelBuilder.Entity("AutoCallsApi.Models.MasiveCall", b =>
                {
                    b.Navigation("Calls");
                });
#pragma warning restore 612, 618
        }
    }
}
