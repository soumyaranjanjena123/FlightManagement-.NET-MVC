using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using AirlineManagement.Entities;
using System.ComponentModel.DataAnnotations;

namespace AirlineManagement.Entities
{
    [Microsoft.EntityFrameworkCore.Index(nameof(TicketId), IsUnique = true)]
    
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; } 
        public string PassengerName {  get; set; }
        public string FlightNumber {  get; set; }
        
        public DateTime DepartureDate {  get; set; }
        public DateTime DepartureTime { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public bool IsConfirmed { get; set; } = false;
    }


}
