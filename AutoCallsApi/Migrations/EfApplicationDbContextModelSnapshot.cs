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

                    b.Property<byte[]>("AudioData")
                        .IsRequired()
                        .HasColumnType("bytea");

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

                    b.HasKey("Id");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("AutoCallsApi.Models.Number", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CallId")
                        .HasColumnType("integer");

                    b.Property<string>("NumberValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CallId");

                    b.ToTable("Numbers");
                });

            modelBuilder.Entity("AutoCallsApi.Models.Number", b =>
                {
                    b.HasOne("AutoCallsApi.Models.Call", null)
                        .WithMany("Numbers")
                        .HasForeignKey("CallId");
                });

            modelBuilder.Entity("AutoCallsApi.Models.Call", b =>
                {
                    b.Navigation("Numbers");
                });
#pragma warning restore 612, 618
        }
    }
}
