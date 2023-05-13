using System.ComponentModel.DataAnnotations;

namespace TravelBookingAPI.Models
{
    public class Flight {

        [Key]
        public string FlightCode { get; set; }
        public string AirLineCode { get; set; }
        public string FlightName { get; set; }



    }
}
