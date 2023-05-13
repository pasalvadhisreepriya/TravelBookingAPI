using TravelBookingAPI.Models;

namespace TravelBookingAPI.Repository.IRepository
{
    public interface IJourneyRepository
    {
        public void Create(Journey journey);
        public void Update(Journey journey);
        public void Delete(int id);
        public IEnumerable<Journey> Get();
        public void Save();
    }
}
