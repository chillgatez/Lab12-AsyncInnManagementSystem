using Lab12_AsyncInnManagementSystem.Data;
using Lab12_AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Lab12_AsyncInnManagementSystem.Models.Services
{
    public class RoomService : IRoom
    {
        private readonly AsyncInnContext _context;

        public RoomService(AsyncInnContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return new NotFoundResult();
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
        {
            return await _context.Room
                .Include(r => r.HotelRooms)
                .ThenInclude(hr => hr.Hotel)
                .Include(r => r.RoomAmenities)
                .ThenInclude(ra => ra.Amenity)
                .ToListAsync();
        }

        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            return await _context.Room.FindAsync(id);
        }

        public bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.ID == id);
        }

        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }

            return new NoContentResult();
        }

        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            var room = await _context.Room.FindAsync(roomId);
            if (room == null)
            {
                return new NotFoundResult();
            }

            var amenity = await _context.Amenity.FindAsync(amenityId);
            if (amenity == null)
            {
                return new NotFoundResult();
            }

            var newRA = new RoomAmenity { AmenityID = amenityId, RoomID = roomId };
            _context.RoomAmenities.Add(newRA);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<IActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var roomAmenity = await _context.RoomAmenity
                .FirstOrDefaultAsync(ra => ra.RoomID == roomId && ra.AmenityID == amenityId);

            if (roomAmenity == null)
            {
                return new NotFoundResult();
            }

            _context.RoomAmenity.Remove(roomAmenity);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
