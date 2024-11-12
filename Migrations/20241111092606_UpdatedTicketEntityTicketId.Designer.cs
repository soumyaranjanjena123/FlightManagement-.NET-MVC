﻿// <auto-generated />
using System;
using AirlineManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirlineManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241111092606_UpdatedTicketEntityTicketId")]
    partial class UpdatedTicketEntityTicketId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirlineManagement.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableSeats = 50,
                            DepartureDate = new DateTime(2024, 11, 13, 14, 56, 3, 503, DateTimeKind.Local).AddTicks(2016),
                            DepartureTime = new DateTime(2024, 11, 14, 0, 56, 3, 503, DateTimeKind.Local).AddTicks(2045),
                            Destination = "Los Angeles",
                            FlightNumber = "AB123",
                            Origin = "New York"
                        },
                        new
                        {
                            Id = 2,
                            AvailableSeats = 30,
                            DepartureDate = new DateTime(2024, 11, 14, 14, 56, 3, 503, DateTimeKind.Local).AddTicks(2052),
                            DepartureTime = new DateTime(2024, 11, 15, 2, 56, 3, 503, DateTimeKind.Local).AddTicks(2053),
                            Destination = "Chicago",
                            FlightNumber = "CD456",
                            Origin = "San Francisco"
                        },
                        new
                        {
                            Id = 3,
                            AvailableSeats = 25,
                            DepartureDate = new DateTime(2024, 11, 16, 14, 56, 3, 503, DateTimeKind.Local).AddTicks(2058),
                            DepartureTime = new DateTime(2024, 11, 17, 4, 56, 3, 503, DateTimeKind.Local).AddTicks(2060),
                            Destination = "Dallas",
                            FlightNumber = "EF789",
                            Origin = "Miami"
                        });
                });

            modelBuilder.Entity("AirlineManagement.Entities.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<string>("ArrivalLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.HasIndex("TicketId")
                        .IsUnique();

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("AirlineManagement.Entities.UserAccount", b =>
                {
                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserName");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("UserAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
