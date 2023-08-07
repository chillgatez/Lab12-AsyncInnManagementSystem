using Lab12_AsyncInnManagementSystem.Data;
using Lab12_AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _context.Room.ToListAsync();
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
    }
}
