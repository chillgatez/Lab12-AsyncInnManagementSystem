using Microsoft.AspNetCore.Mvc;

namespace Lab12_AsyncInnManagementSystem.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<IEnumerable<HotelRoom>> GetHotelRoom(int hotelID);

        Task<HotelRoom> GetHotelRoom(int hotelId, int roomId);

        Task<HotelRoom> PutHotelRoom(int hotelId, int roomId, HotelRoom hotelRoom);

        Task<HotelRoom> PostHotelRoom(HotelRoom hotelRoom);

        Task<HotelRoom> DeleteHotelRoom(int hotelId, int roomId);

        bool HotelRoomExists(int hotelId, int roomId);
    }
}