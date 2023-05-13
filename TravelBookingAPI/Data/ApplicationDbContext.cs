using Microsoft.EntityFrameworkCore;
using TravelBookingAPI.Models;

namespace TravelBookingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AirLine> AirLines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Journey> Journey { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
