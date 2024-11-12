namespace AirlineManagement.Entities
{
    public class AirlineData
    {
        public string FlightNumber {  get; set; }
        public int SeatNumber {  get; set; }
        public string Origin {  get; set; }
        public string Destination { get; set; }

        public DateTime DepartureTime {  get; set; }
        public DateTime DepartureDate { get; set; }
        public int AvailableSeats { get; set; }
    }
}
