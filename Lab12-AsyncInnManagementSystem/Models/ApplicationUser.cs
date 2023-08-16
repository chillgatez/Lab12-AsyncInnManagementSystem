using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_AsyncInnManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string Id { get; set; }
​
		[Required]
        public string Username { get; set; }
​
​
		public string Password { get; set; }
​
​
		public string Email { get; set; }
​
		public string PhoneNumber { get; set; }
    }
}
