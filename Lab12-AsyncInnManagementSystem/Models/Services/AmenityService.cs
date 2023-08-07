using Lab12_AsyncInnManagementSystem.Data;
using Lab12_AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace Lab12_AsyncInnManagementSystem.Models.Services
{
    public class AmenityService : IAmenity
    {
        private readonly AsyncInnContext _context;

        public AmenityService(AsyncInnContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DeleteAmenity(int id)
        {
            var amenity = await _context.Amenity.FindAsync(id);
            if (amenity == null)
            {
                return new NotFoundResult();
            }

            _context.Amenity.Remove(amenity);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            return await _context.Amenity.ToListAsync();
        }

        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            return await _context.Amenity.FindAsync(id);
        }

        public bool AmenityExists(int id)
        {
            return _context.Amenity.Any(e => e.ID == id);
        }

        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
            _context.Amenity.Add(amenity);
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityExists(id))
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
