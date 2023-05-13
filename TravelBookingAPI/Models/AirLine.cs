using System.ComponentModel.DataAnnotations;

namespace TravelBookingAPI.Models
{
    public class AirLine
    {
        public string AirLineName { get; set; }
        [Key]
        public string AirLineCode { get; set; }
    }
}
