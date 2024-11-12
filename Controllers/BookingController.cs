using AirlineManagement.Entities;
using AirlineManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;
using System.Security.Claims;

namespace AirlineManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;

        }

        [Authorize]
        [HttpGet]
        public IActionResult SearchFlights()
        {
            var model = new SearchFlightViewModel
            {
                AvailableFlight = new List<Flight>()
            };
            return View(model);
            
        }
        [HttpPost]
        [Authorize]
        public IActionResult SearchFlights(SearchFlightViewModel model)
        {
            if(string.IsNullOrEmpty(model.DepartureLocation)|| string.IsNullOrEmpty(model.ArrivalLocation))
            {
                ModelState.AddModelError("", "Both departure and arrival can't be empty");
                return View(model);
            }

            try
            {
                var availableFlights = _context.Flights.Where(f => f.Origin.ToLower() == model.DepartureLocation.ToLower()
                                                              && f.Destination.ToLower() == model.ArrivalLocation.ToLower()
                                                              && f.AvailableSeats > 0).ToList();
                Console.WriteLine($"Search parameter - From {model.DepartureLocation}, to: {model.ArrivalLocation}");
                Console.WriteLine($"Found {availableFlights.Count} Flights");
                model.AvailableFlight = availableFlights;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error searching flights: {ex.Message}");
                ModelState.AddModelError("", "An Error ocured while searching flights");
                model.AvailableFlight = new List<Flight>();
                return View(model);
            }
            return View(model);

        }
        //public IActionResult SearchFlights(string departureLocation, string arrivalLocation)
        //{
        //    if (string.IsNullOrEmpty(departureLocation) || string.IsNullOrEmpty(arrivalLocation)) 
        //    {
        //        ModelState.AddModelError("", "Both departure and arrival can't be empty");
        //        return View();

        //    }

        //    //var availableFlights = _context.Flights.Where(f => f.Origin.ToLower() == departureLocation.ToLower()
        //    //                                                && f.Destination.ToLower() == arrivalLocation.ToLower()
        //    //                                                && f.AvailableSeats > 0).ToList();

        //    var availableFlights = _context.Flights.AsEnumerable().Where(f => f.Origin.Equals(departureLocation, StringComparison.OrdinalIgnoreCase)
        //                                                                 && f.Destination.Equals(arrivalLocation, StringComparison.OrdinalIgnoreCase)
        //                                                                 && f.AvailableSeats > 0).ToList();

        //    Console.WriteLine(availableFlights);

        //    //var availableFlights = _context.Flights
        //    //        .FromSqlRaw("SELECT * FROM Flights WHERE Origin = {0} AND Destination = {1} AND AvailableSeats > 0", departureLocation, arrivalLocation)
        //    //        .ToList();


        //    return View("AvailableFlights", availableFlights);
        //}

        //[Authorize]
        //public IActionResult AvailableFlights(List<Flight> availableFlights)
        //{
        //    return View(availableFlights);
        //}

        [Authorize]
        [HttpGet]
        public IActionResult BookTicket(string flightNumber)
        
        {
            var flight = _context.Flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
            if(flight == null)
            {
                return NotFound("flight not found");
            }

            var model = new BookingViewModel
            {
                FlightNumber = flight.FlightNumber,
                DepartureLocation = flight.Origin,
                ArrivalLocation = flight.Destination,
                DepartureDate = flight.DepartureDate,
                
                AvailableSeats = flight.AvailableSeats
            };
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult BookTicket(BookingViewModel bookingViewModel) 
         {
            if (ModelState.IsValid)
            {
                var flight = _context.Flights.FirstOrDefault(f=>f.FlightNumber == bookingViewModel.FlightNumber);
                if(flight !=null && flight.AvailableSeats > 0)
                {
                    var passengerName = User.FindFirstValue(ClaimTypes.Name);
                    //var random = new Random();
                    //int ticketId = random.Next(1000, 9999);
                    var ticket = new Ticket
                    {
                        //TicketId = ticketId,
                        PassengerName = passengerName,
                        FlightNumber = flight.FlightNumber,
                        DepartureDate = flight.DepartureDate,
                        DepartureTime = flight.DepartureTime,
                        DepartureLocation = flight.Origin,
                        ArrivalLocation = flight.Destination,
                        IsConfirmed = true

                    };

                    flight.AvailableSeats--;

                    _context.Tickets.Add(ticket);
                    _context.SaveChanges();

                    //ViewBag.Message = "Ticket booked successfull";
                    TempData["BookingMessage"] = "Ticket booked successfull";

                    return RedirectToAction("ViewTickets","Booking");
                }
                else
                {
                    ModelState.AddModelError("", "Sorry no available seats for this flight");
                }
            }
            return View(bookingViewModel);
        }

        [Authorize]
        public IActionResult ViewTickets()
        {
            var passengerName = User.FindFirstValue(ClaimTypes.Name);
            var tickets = _context.Tickets.Where(t=>t.PassengerName == passengerName).ToList();
            return View(tickets);
        }
       
        public IActionResult Index()
        {
            var flights = _context.Flights.ToList();
            Console.WriteLine($"Total flight in database: {flights.Count}");
            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight {flight.FlightNumber}: {flight.Origin} to {flight.Destination}");

            }
            return View();
        }
    }
}
