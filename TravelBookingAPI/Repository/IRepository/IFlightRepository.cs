using TravelBookingAPI.Models;

namespace TravelBookingAPI.Repository.IRepository
{
    public interface IFlightRepository
    {
        public void Create(Flight flight);
            public void Update(Flight flight);
            public void Delete(string flightCode);
            public IEnumerable<Flight> Get();
            public void Save();
        
    }
}
