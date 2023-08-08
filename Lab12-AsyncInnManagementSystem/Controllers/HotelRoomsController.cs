using Lab12_AsyncInnManagementSystem.Data;
using Lab12_AsyncInnManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_AsyncInnManagementSystem.Controllers
{
    //https://localhost:7280/api/HotelRooms
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly AsyncInnContext _context;

        public HotelRoomsController(AsyncInnContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRoom()
        {
            return await _context.HotelRoom
                .Include(hr => hr.Room)
                .ToListAsync();
        }

        [HttpGet("{hotelId}/{roomId}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomId)
        {
            var hotelRoom = await _context.HotelRoom
                .Include(hr => hr.Room)
                .Include(hr => hr.Hotel)
                .FirstOrDefaultAsync(hr => hr.RoomID == roomId && hr.HotelID == hotelId);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        [HttpPut("{hotelId}/{roomId}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomId, HotelRoom hotelRoom)
        {
            if (hotelId != hotelRoom.HotelID || roomId != hotelRoom.RoomID)
            {
                return BadRequest();
            }

            _context.Entry(hotelRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRoomExists(hotelId, roomId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRoom.Add(hotelRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelRoom", new { hotelId = hotelRoom.HotelID, roomId = hotelRoom.RoomID }, hotelRoom);
        }

        [HttpDelete("{hotelId}/{roomId}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelId, int roomId)
        {
            var hotelRoom = await _context.HotelRoom
                .FirstOrDefaultAsync(hr => hr.RoomID == roomId && hr.HotelID == hotelId);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            _context.HotelRoom.Remove(hotelRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelRoomExists(int hotelId, int roomId)
        {
            return _context.HotelRoom.Any(hr => hr.RoomID == roomId && hr.HotelID == hotelId);
        }
    }
}
