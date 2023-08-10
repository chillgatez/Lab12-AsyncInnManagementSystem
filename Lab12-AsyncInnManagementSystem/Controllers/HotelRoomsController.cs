using Lab12_AsyncInnManagementSystem.Data;
using Lab12_AsyncInnManagementSystem.Models;
using Lab12_AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_AsyncInnManagementSystem.Controllers
{
    [Route("api/Hotels/{hotelId}/Rooms")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoomService;

        public HotelRoomsController(IHotelRoom hotelRoomService)
        {
            _hotelRoomService = hotelRoomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRoom(int hotelId)
        {
            var hotelRooms = await _hotelRoomService.GetHotelRoom(hotelId);
            return Ok(hotelRooms);
        }

        [HttpGet("{roomId}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomId)
        {
            var hotelRoom = await _hotelRoomService.GetHotelRoom(hotelId, roomId);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            return Ok(hotelRoom);
        }

        [HttpPut("{roomId}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomId, HotelRoom hotelRoom)
        {
            if (roomId != hotelRoom.RoomID)
            {
                return BadRequest();
            }

            try
            {
                var updatedHotelRoom = await _hotelRoomService.PutHotelRoom(hotelId, roomId, hotelRoom);
                return Ok(updatedHotelRoom);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int hotelId, HotelRoom hotelRoom)
        {
            if (hotelId != hotelRoom.HotelID)
            {
                return BadRequest();
            }

            var createdHotelRoom = await _hotelRoomService.PostHotelRoom(hotelRoom);
            return CreatedAtAction(nameof(GetHotelRoom), new { hotelId, roomId = createdHotelRoom.RoomID }, createdHotelRoom);
        }

        [HttpDelete("{roomId}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelId, int roomId)
        {
            var deletedRoom = await _hotelRoomService.DeleteHotelRoom(hotelId, roomId);

            if (deletedRoom != null)
            {
                return NoContent();
            }

            return NotFound();
        }

        private bool HotelRoomExists(int hotelId, int roomId)
        {
            return _hotelRoomService.HotelRoomExists(hotelId, roomId);
        }
    }
}
