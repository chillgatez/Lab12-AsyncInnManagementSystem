﻿using System.ComponentModel.DataAnnotations;

namespace Lab12_AsyncInnManagementSystem.Models
{
    public class HotelRoom
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int RoomID { get; set; }
        [Required]
        public int HotelID { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
