using AirlineManagement.Entities;

namespace AirlineManagement.Models
{
    public class SearchFlightViewModel
    {
        public string DepartureLocation {  get; set; }
        public string ArrivalLocation {  get; set; }
        public List<Flight> AvailableFlight { get; set; } = new List<Flight>();
    }
}
