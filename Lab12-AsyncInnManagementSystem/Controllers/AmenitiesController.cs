using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12_AsyncInnManagementSystem.Data;
using Lab12_AsyncInnManagementSystem.Models;
using Lab12_AsyncInnManagementSystem.Models.Interfaces;
using Lab12_AsyncInnManagementSystem.Models.Services;

namespace Lab12_AsyncInnManagementSystem.Controllers
{
    //https://https://localhost:7280/api/Amenities
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenity()
        {
            return await _amenity.GetAmenity();
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            return await _amenity.GetAmenity(id);
        }

        // PUT: api/Amenities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.ID)
            {
                return BadRequest();
            }

            return await _amenity.PutAmenity(id, amenity);
        }

        // POST: api/Amenities
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
            return await _amenity.PostAmenity(amenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            return await _amenity.DeleteAmenity(id);
        }

        private bool AmenityExists(int id)
        {
            return _amenity.AmenityExists(id);
        }
    }
}
