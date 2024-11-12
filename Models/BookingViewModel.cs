using AirlineManagement.Entities;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace AirlineManagement.Models
{
    public class BookingViewModel
    {
        [Required]
        public string FlightNumber { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public string DepartureLocation {  get; set; }
        [Required]
        public string ArrivalLocation {  get; set; }

        public int AvailableSeats { get; set; }

    }
}
