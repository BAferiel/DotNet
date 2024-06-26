﻿// <auto-generated />
using System;
using AM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Data.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20240417193721_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AM.Core.Domain.Flight", b =>
                {
                    b.Property<int>("FlighttId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlighttId"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EffectiveArrival")
                        .HasColumnType("bit");

                    b.Property<float>("EstimatedDuration")
                        .HasColumnType("real");

                    b.Property<DateTime>("FLightDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int");

                    b.HasKey("FlighttId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AM.Core.Domain.Passenger", b =>
                {
                    b.Property<long>("PassportNumber")
                        .HasMaxLength(7)
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BirdthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsTraveller")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Telnumber")
                        .HasMaxLength(25)
                        .HasColumnType("bigint");

                    b.HasKey("PassportNumber");

                    b.ToTable("Passengers");

                    b.HasDiscriminator<string>("IsTraveller").HasValue("0");
                });

            modelBuilder.Entity("AM.Core.Domain.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneId"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("PlaneCapacity");

                    b.Property<DateTime>("ManufactoreDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("planeType")
                        .HasColumnType("int");

                    b.HasKey("PlaneId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("AM.Core.Domain.Reservation", b =>
                {
                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<long>("PassengerId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VIP")
                        .HasColumnType("bit");

                    b.HasKey("FlightId", "ReservationId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.Property<int>("flightsFlighttId")
                        .HasColumnType("int");

                    b.Property<long>("passengersPassportNumber")
                        .HasColumnType("bigint");

                    b.HasKey("flightsFlighttId", "passengersPassportNumber");

                    b.HasIndex("passengersPassportNumber");

                    b.ToTable("FlightPassenger");
                });

            modelBuilder.Entity("AM.Core.Domain.Staff", b =>
                {
                    b.HasBaseType("AM.Core.Domain.Passenger");

                    b.Property<DateTime>("EmployementDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue("2");
                });

            modelBuilder.Entity("AM.Core.Domain.Traveller", b =>
                {
                    b.HasBaseType("AM.Core.Domain.Passenger");

                    b.Property<string>("HealthyInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("1");
                });

            modelBuilder.Entity("AM.Core.Domain.Flight", b =>
                {
                    b.HasOne("AM.Core.Domain.Plane", "plane")
                        .WithMany("flights")
                        .HasForeignKey("PlaneId")
                        .IsRequired();

                    b.Navigation("plane");
                });

            modelBuilder.Entity("AM.Core.Domain.Passenger", b =>
                {
                    b.OwnsOne("AM.Core.Domain.FullName", "FullName", b1 =>
                        {
                            b1.Property<long>("PassengerPassportNumber")
                                .HasColumnType("bigint");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)")
                                .HasColumnName("PassFilghtsName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PassengerPassportNumber");

                            b1.ToTable("Passengers");

                            b1.WithOwner()
                                .HasForeignKey("PassengerPassportNumber");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("AM.Core.Domain.Reservation", b =>
                {
                    b.HasOne("AM.Core.Domain.Flight", "Flight")
                        .WithMany("Reservations")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.Core.Domain.Passenger", "Passenger")
                        .WithMany("Reservations")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.HasOne("AM.Core.Domain.Flight", null)
                        .WithMany()
                        .HasForeignKey("flightsFlighttId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.Core.Domain.Passenger", null)
                        .WithMany()
                        .HasForeignKey("passengersPassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.Core.Domain.Flight", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AM.Core.Domain.Passenger", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AM.Core.Domain.Plane", b =>
                {
                    b.Navigation("flights");
                });
#pragma warning restore 612, 618
        }
    }
}
