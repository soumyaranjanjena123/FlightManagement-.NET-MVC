using Microsoft.EntityFrameworkCore;

namespace AirlineManagement.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<UserAccount> UserAccounts  { get; set; }
        
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Flight> Flights { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flight>().HasData(
                new Flight
                {
                    Id = 1,
                    FlightNumber = "AB123",
                    Origin = "New York",
                    Destination = "Los Angeles",
                    DepartureDate = DateTime.Now.AddDays(2), // Example date
                    DepartureTime = DateTime.Now.AddDays(2).AddHours(10), // Example time
                    AvailableSeats = 50
                },
            new Flight
            {
                Id = 2,
                FlightNumber = "CD456",
                Origin = "San Francisco",
                Destination = "Chicago",
                DepartureDate = DateTime.Now.AddDays(3), // Example date
                DepartureTime = DateTime.Now.AddDays(3).AddHours(12), // Example time
                AvailableSeats = 30
            },
            new Flight
            {
                Id = 3,
                FlightNumber = "EF789",
                Origin = "Miami",
                Destination = "Dallas",
                DepartureDate = DateTime.Now.AddDays(5), // Example date
                DepartureTime = DateTime.Now.AddDays(5).AddHours(14), // Example time
                AvailableSeats = 25
            }
            );
            
        }

    }
}
