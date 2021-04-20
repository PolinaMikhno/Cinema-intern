﻿// <auto-generated />
using System;
using Cinema.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.DAL.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20210420085555_RenameTables")]
    partial class RenameTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cinema.DAL.Auth.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Film", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Hall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TheaterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TheaterId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Sessions.AdditionalService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("AdditionalServices");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Sessions.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HallId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TheaterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("HallId");

                    b.HasIndex("TheaterId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.SittingPlace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HallId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<int>("SittingPlaceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.ToTable("SittingPlaces");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Theater", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Theaters");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Hall", b =>
                {
                    b.HasOne("Cinema.DAL.Entities.Theater", null)
                        .WithMany("Halls")
                        .HasForeignKey("TheaterId");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Sessions.AdditionalService", b =>
                {
                    b.HasOne("Cinema.DAL.Entities.Sessions.Session", null)
                        .WithMany("AdditionalServices")
                        .HasForeignKey("SessionId");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Sessions.Session", b =>
                {
                    b.HasOne("Cinema.DAL.Entities.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId");

                    b.HasOne("Cinema.DAL.Entities.Hall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallId");

                    b.HasOne("Cinema.DAL.Entities.Theater", "Theater")
                        .WithMany()
                        .HasForeignKey("TheaterId");

                    b.Navigation("Film");

                    b.Navigation("Hall");

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.SittingPlace", b =>
                {
                    b.HasOne("Cinema.DAL.Entities.Hall", null)
                        .WithMany("Places")
                        .HasForeignKey("HallId");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Hall", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Sessions.Session", b =>
                {
                    b.Navigation("AdditionalServices");
                });

            modelBuilder.Entity("Cinema.DAL.Entities.Theater", b =>
                {
                    b.Navigation("Halls");
                });
#pragma warning restore 612, 618
        }
    }
}
