﻿// <auto-generated />
using System;
using Boilerplate.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Boilerplate.Infrastructure.Migrations
{
    [DbContext(typeof(HeroDbContext))]
    [Migration("20210926151006_DisplayHour")]
    partial class DisplayHour
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Boilerplate.Domain.Entities.Hero", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("HeroType")
                        .HasColumnType("int");

                    b.Property<string>("Individuality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Team")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Boilerplate.Domain.Entities.Theater.MovieEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DisplayEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DisplayStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Boilerplate.Domain.Entities.Theater.ReservationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<Guid?>("TheaterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TimeSlotId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TheaterId");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Boilerplate.Domain.Entities.Theater.TheaterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Columns")
                        .HasColumnType("int");

                    b.Property<int>("Rows")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Theaters");
                });

            modelBuilder.Entity("Boilerplate.Domain.Entities.Theater.TimeSlotEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DisplayHour")
                        .HasColumnType("int");

                    b.Property<Guid>("MovieEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MovieEntityId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("Boilerplate.Domain.Entities.Theater.ReservationEntity", b =>
                {
                    b.HasOne("Boilerplate.Domain.Entities.Theater.TheaterEntity", "Theater")
                        .WithMany("Reservations")
                        .HasForeignKey("TheaterId");

                    b.HasOne("Boilerplate.Domain.Entities.Theater.TimeSlotEntity", "TimeSlot")
                        .WithMany()
                        .HasForeignKey("TimeSlotId");

                    b.Navigation("Theater");

                    b.Navigation("TimeSlot");
                });

            modelBuilder.Entity("Boilerplate.Domain.Entities.Theater.TimeSlotEntity", b =>
                {
                    b.HasOne("Boilerplate.Domain.Entities.Theater.MovieEntity", null)
                        .WithMany("TimeSlots")
                        .HasForeignKey("MovieEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Boilerplate.Domain.Entities.Theater.MovieEntity", b =>
                {
                    b.Navigation("TimeSlots");
                });

            modelBuilder.Entity("Boilerplate.Domain.Entities.Theater.TheaterEntity", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
