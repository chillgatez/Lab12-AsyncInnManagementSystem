using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab12_AsyncInnManagementSystem.Models.Interfaces
{
    public interface IRoom
    {
        public Task<ActionResult<IEnumerable<Room>>> GetRoom();

        public Task<ActionResult<Room>> GetRoom(int id);

        public Task<IActionResult> PutRoom(int id, Room room);

        public Task<ActionResult<Room>> PostRoom(Room room);

        public Task<IActionResult> DeleteRoom(int id);

        public Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId);

        public Task<IActionResult> RemoveAmenityFromRoom(int roomId, int amenityId);

        public bool RoomExists(int id);
    }
}
