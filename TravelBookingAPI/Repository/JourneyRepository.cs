using TravelBookingAPI.Data;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository.IRepository;

namespace TravelBookingAPI.Repository
{
    public class JourneyRepository : IJourneyRepository

    {

        private readonly ApplicationDbContext _applicationDbContext;

        public JourneyRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
        }
        public void Create(Journey journey)
        {
            _applicationDbContext.Journey.Add(journey);

        }

        public void Delete(int id)
        {
            Journey journey = _applicationDbContext.Journey.Find(id);
            _applicationDbContext.Journey.Remove(journey);
        }

        public IEnumerable<Journey> Get()
        {

            return _applicationDbContext.Journey.ToList();
        }

        public void Update(Journey journey)
        {
            _applicationDbContext.Journey.Update(journey);
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
