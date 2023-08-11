﻿// <auto-generated />
using System;
using Lab12_AsyncInnManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab12_AsyncInnManagementSystem.Migrations
{
    [DbContext(typeof(AsyncInnContext))]
    [Migration("20230810164620_AmenityEdit")]
    partial class AmenityEdit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Amenity");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "A/C"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Iron"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Microwave"
                        });
                });

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotel");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "123 Sesame St",
                            City = "Memphis",
                            Name = "Elmo's Hotel",
                            Phone = "555-555-5555",
                            State = "TN"
                        },
                        new
                        {
                            ID = 2,
                            Address = "456 Pickup Sticks Ln",
                            City = "Memphis",
                            Name = "Ya Mama's Inn",
                            Phone = "444-444-4444",
                            State = "TN"
                        },
                        new
                        {
                            ID = 3,
                            Address = "789 Kitty Cat Cr",
                            City = "Atlanta",
                            Name = "Kitten's Bed & Breakfast",
                            Phone = "101-010-1010",
                            State = "GA"
                        });
                });

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.HotelRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRoom");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            HotelID = 1,
                            Price = 100.98999999999999,
                            RoomID = 1,
                            RoomNumber = 101
                        },
                        new
                        {
                            ID = 2,
                            HotelID = 1,
                            Price = 149.99000000000001,
                            RoomID = 2,
                            RoomNumber = 201
                        },
                        new
                        {
                            ID = 3,
                            HotelID = 2,
                            Price = 69.989999999999995,
                            RoomID = 1,
                            RoomNumber = 102
                        },
                        new
                        {
                            ID = 4,
                            HotelID = 2,
                            Price = 169.99000000000001,
                            RoomID = 3,
                            RoomNumber = 301
                        },
                        new
                        {
                            ID = 5,
                            HotelID = 3,
                            Price = 99.989999999999995,
                            RoomID = 2,
                            RoomNumber = 202
                        },
                        new
                        {
                            ID = 6,
                            HotelID = 3,
                            Price = 159.99000000000001,
                            RoomID = 3,
                            RoomNumber = 302
                        });
                });

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AmenityID")
                        .HasColumnType("int");

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AmenityID");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 0,
                            Name = "Basic Room"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 1,
                            Name = "Basic Single Room"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 2,
                            Name = "Basic Double Room"
                        });
                });

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.RoomAmenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AmenityID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AmenityID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomAmenity");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AmenityID = 1,
                            RoomID = 1
                        },
                        new
                        {
                            ID = 5,
                            AmenityID = 3,
                            RoomID = 1
                        },
                        new
                        {
                            ID = 7,
                            AmenityID = 1,
                            RoomID = 2
                        },
                        new
                        {
                            ID = 3,
                            AmenityID = 2,
                            RoomID = 2
                        },
                        new
                        {
                            ID = 4,
                            AmenityID = 3,
                            RoomID = 3
                        },
                        new
                        {
                            ID = 6,
                            AmenityID = 4,
                            RoomID = 3
                        });
                });

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.HotelRoom", b =>
                {
                    b.HasOne("Lab12_AsyncInnManagementSystem.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab12_AsyncInnManagementSystem.Models.Room", "Room")
                        .WithMany("HotelRooms")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.Room", b =>
                {
                    b.HasOne("Lab12_AsyncInnManagementSystem.Models.Amenity", null)
                        .WithMany("Rooms")
                        .HasForeignKey("AmenityID");
                });

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.RoomAmenity", b =>
                {
                    b.HasOne("Lab12_AsyncInnManagementSystem.Models.Amenity", "Amenity")
                        .WithMany()
                        .HasForeignKey("AmenityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab12_AsyncInnManagementSystem.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.Amenity", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.Hotel", b =>
                {
                    b.Navigation("HotelRooms");
                });

            modelBuilder.Entity("Lab12_AsyncInnManagementSystem.Models.Room", b =>
                {
                    b.Navigation("HotelRooms");

                    b.Navigation("RoomAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
