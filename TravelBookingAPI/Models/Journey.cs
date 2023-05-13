using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingAPI.Models
{
    public class Journey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string FromCity { get; set; }
        public string ToCity { get; set; }
            
        public DateTime TravelDate { get; set; }
        public string AirLineCode { get; set; }

        public string FlightCode { get; set; }
        public int NumberOfPassengers { get; set; }
        
    }
}
