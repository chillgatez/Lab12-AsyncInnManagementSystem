/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12_AsyncInnManagementSystem.Data;
using Lab12_AsyncInnManagementSystem.Models;

namespace Lab12_AsyncInnManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAmenitiesController : ControllerBase
    {
        private readonly AsyncInnContext _context;

        public RoomAmenitiesController(AsyncInnContext context)
        {
            _context = context;
        }

        // GET: api/RoomAmenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomAmenity>>> GetRoomAmenities()
        {
          if (_context.RoomAmenities == null)
          {
              return NotFound();
          }
            return await _context.RoomAmenities.ToListAsync();
        }

        // GET: api/RoomAmenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomAmenity>> GetRoomAmenity(int id)
        {
          if (_context.RoomAmenities == null)
          {
              return NotFound();
          }
            var roomAmenity = await _context.RoomAmenities.FindAsync(id);

            if (roomAmenity == null)
            {
                return NotFound();
            }

            return roomAmenity;
        }

        // PUT: api/RoomAmenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomAmenity(int id, RoomAmenity roomAmenity)
        {
            if (id != roomAmenity.ID)
            {
                return BadRequest();
            }

            _context.Entry(roomAmenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomAmenityExists(id))
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

        // POST: api/RoomAmenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomAmenity>> PostRoomAmenity(RoomAmenity roomAmenity)
        {
          if (_context.RoomAmenities == null)
          {
              return Problem("Entity set 'AsyncInnContext.RoomAmenities'  is null.");
          }
            _context.RoomAmenities.Add(roomAmenity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomAmenity", new { id = roomAmenity.ID }, roomAmenity);
        }

        // DELETE: api/RoomAmenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomAmenity(int id)
        {
            if (_context.RoomAmenities == null)
            {
                return NotFound();
            }
            var roomAmenity = await _context.RoomAmenities.FindAsync(id);
            if (roomAmenity == null)
            {
                return NotFound();
            }

            _context.RoomAmenities.Remove(roomAmenity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomAmenityExists(int id)
        {
            return (_context.RoomAmenities?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}*/