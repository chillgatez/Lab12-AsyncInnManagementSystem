/*using Lab12_AsyncInnManagementSystem.Data;
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

        public async Task<IActionResult> DeleteHotelRoom(int roomId, int hotelId)
        {
            var hotelRoom = await _context.HotelRoom
                .FirstOrDefaultAsync(hr => hr.RoomID == roomId && hr.HotelID == hotelId);

            if (hotelRoom == null)
            {
                return new NotFoundResult();
            }

            _context.HotelRoom.Remove(hotelRoom);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRoom(int hotelId)
        {
            return await _context.HotelRoom
                .Include(hr => hr.Room)
                .Where(hr => hr.HotelID == hotelId)
                .ToListAsync();
        }

        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int roomId, int hotelId)
        {
            var hotelRoom =  await _context.HotelRoom
                .Include(hr => hr.Room)
                .Include(hr => hr.Hotel)
                .FirstOrDefaultAsync(hr => hr.RoomID == roomId);

            if (hotelRoom == null)
            {
                return new NotFoundResult();
            }

            return hotelRoom;
        }

        public bool HotelRoomExists(int roomId, int hotelId)
        {
            return _context.HotelRoom.Any(hr => hr.RoomID == roomId && hr.HotelID == hotelId);
        }

        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRoom.Add(hotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<IActionResult> PutHotelRoom(int roomId, int hotelId, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRoomExists(roomId, hotelId)) 
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

    }

}
*/