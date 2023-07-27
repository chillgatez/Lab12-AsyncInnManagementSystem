using System.ComponentModel.DataAnnotations;

namespace Lab12.Models
{
    public class Amenity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    
    }
}
