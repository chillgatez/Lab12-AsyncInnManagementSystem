using Lab12_AsyncInnManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab12_AsyncInnManagementSystem.Data
{
    public class AsyncInnContext: DbContext 
    {
        //class should have singular name, object instantiation should be plural for readability
        public DbSet<Amenity> Amenities { get; set; } = default!;
        public DbSet<RoomAmenity> RoomAmenities { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<HotelRoom> HotelRooms { get; set; } = default!;
        public DbSet<Hotel> Hotels { get; set; } = default!;

        public AsyncInnContext(DbContextOptions<AsyncInnContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //information tables
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { ID = 1, Name = "A/C" },
                new Amenity { ID = 2, Name = "Iron"},
                new Amenity { ID = 3, Name = "Microwave"});

            modelBuilder.Entity<Room>().HasData(
                new Room { ID = 1, Layout = 0, Name = "Basic Room" },
                new Room { ID = 2, Layout = 1, Name = "Basic Single Room" },
                new Room { ID = 3, Layout = 2, Name = "Basic Double Room" });
            
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Address = "123 Sesame St",
                    City = "Memphis",
                    State = "TN",
                    Name = "Elmo's Hotel",
                    Phone = "555-555-5555"
                },
                new Hotel
                {
                    ID = 2,
                    Address = "456 Pickup Sticks Ln",
                    City = "Memphis",
                    State = "TN",
                    Name = "Ya Mama's Inn",
                    Phone = "444-444-4444"
                },
                new Hotel
                {
                    ID = 3,
                    Address = "789 Kitty Cat Cr",
                    City = "Atlanta",
                    State = "GA",
                    Name = "Kitten's Bed & Breakfast",
                    Phone = "101-010-1010"
                });

            //reference tables
            modelBuilder.Entity<RoomAmenity>().HasData(
                new RoomAmenity { ID = 1, AmenityID = 1, RoomID = 1 },
                new RoomAmenity { ID = 5, AmenityID = 3, RoomID = 1 },
                new RoomAmenity { ID = 7, AmenityID = 1, RoomID = 2 },
                new RoomAmenity { ID = 3, AmenityID = 2, RoomID = 2 },
                new RoomAmenity { ID = 4, AmenityID = 3, RoomID = 3 },
                new RoomAmenity { ID = 6, AmenityID = 4, RoomID = 3 }
                );
            modelBuilder.Entity<HotelRoom>().HasData(
                new HotelRoom { ID = 1, HotelID = 1, RoomID = 1, RoomNumber = 101, Price = 100.99 },
                new HotelRoom { ID = 2, HotelID = 1, RoomID = 2, RoomNumber = 201, Price = 149.99 },
                new HotelRoom { ID = 3, HotelID = 2, RoomID = 1, RoomNumber = 102, Price = 69.99 },
                new HotelRoom { ID = 4, HotelID = 2, RoomID = 3, RoomNumber = 301, Price = 169.99 },
                new HotelRoom { ID = 5, HotelID = 3, RoomID = 2, RoomNumber = 202, Price = 99.99 },
                new HotelRoom { ID = 6, HotelID = 3, RoomID = 3, RoomNumber = 302, Price = 159.99 }
                );
        }

        public DbSet<Lab12_AsyncInnManagementSystem.Models.Hotel> Hotel { get; set; } = default!;

        public DbSet<Lab12_AsyncInnManagementSystem.Models.Amenity> Amenity { get; set; } = default!;

        public DbSet<Lab12_AsyncInnManagementSystem.Models.Room> Room { get; set; } = default!;

        public DbSet<Lab12_AsyncInnManagementSystem.Models.HotelRoom> HotelRoom { get; set; } = default!;

        public DbSet<Lab12_AsyncInnManagementSystem.Models.RoomAmenity> RoomAmenity { get; set; } = default!;

    }
}



