using System.ComponentModel.DataAnnotations;

namespace AirlineManagement.Entities
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }

    }
}
