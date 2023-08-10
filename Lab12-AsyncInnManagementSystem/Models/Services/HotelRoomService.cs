using Lab12_AsyncInnManagementSystem.Data;
using Lab12_AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_AsyncInnManagementSystem.Models.Services
{
    public class HotelRoomService : IHotelRoom
    {
        private readonly AsyncInnContext _context;

        public HotelRoomService(AsyncInnContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HotelRoom>> GetHotelRoom(int hotelID)
        {
            var hotelRooms = await _context.HotelRoom
                .Include(hr => hr.Room)
                .ThenInclude(r => r.Name)
                .Where(hr => hr.HotelID == hotelID)
                .ToListAsync();
            return hotelRooms;
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomId)
        {
            var hotelRoom = await _context.HotelRoom
                .Include(hr => hr.Room)
                .Include(hr => hr.Hotel)
                .FirstOrDefaultAsync(hr => hr.RoomID == roomId && hr.HotelID == hotelId);
            return hotelRoom;
        }

        public async Task<HotelRoom> PutHotelRoom(int hotelId, int roomId, HotelRoom hotelRoom)
        {
            if (hotelId != hotelRoom.HotelID || roomId != hotelRoom.RoomID)
            {
                throw new ArgumentException("Hotel ID or Room ID mismatch.");
            }

            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<HotelRoom> PostHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRoom.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<HotelRoom> DeleteHotelRoom(int hotelId, int roomId)
        {
            var hotelRoom = await _context.HotelRoom
                .FirstOrDefaultAsync(hr => hr.RoomID == roomId && hr.HotelID == hotelId);

            if (hotelRoom == null)
            {
                return null;
            }

            _context.HotelRoom.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public bool HotelRoomExists(int roomId, int hotelId)
        {
            var roomExists = _context.HotelRoom.Any(hr => hr.RoomID == roomId && hr.HotelID == hotelId);

            if (!roomExists)
            {
                // Check if the room exists in the Room table
                var roomExistsInDatabase = _context.Room.Any(r => r.ID == roomId);

                if (!roomExistsInDatabase)
                {
                    return false;
                }
            }

            return roomExists;
        }
    }
}