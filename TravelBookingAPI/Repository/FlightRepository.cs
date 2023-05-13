using TravelBookingAPI.Data;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository.IRepository;

namespace TravelBookingAPI.Repository
{
    public class FlightRepository :IFlightRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public FlightRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
        }
        public void Create(Flight flight)
        {
            _applicationDbContext.Flights.Add(flight);

        }

        public void Delete(string flightCode)
        {
            Flight flight = _applicationDbContext.Flights.Find(flightCode);
            _applicationDbContext.Flights.Remove(flight);
        }

        public IEnumerable<Flight> Get()
        {

            return _applicationDbContext.Flights.ToList();
        }

        public void Update(Flight flight)
        {
            _applicationDbContext.Flights.Update(flight);
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
