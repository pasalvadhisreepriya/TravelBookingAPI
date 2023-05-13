using System.ComponentModel.DataAnnotations;

namespace TravelBookingAPI.Models
{
    public class User
    {
        public string Name { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }    
        public string Role { get; set; }   
    }
}
