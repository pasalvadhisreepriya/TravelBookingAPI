using TravelBookingAPI.Models;

namespace TravelBookingAPI.Repository.IRepository
{
    public interface IAirLineRepository
    {
        public void Create(AirLine airLine);
        public IEnumerable<AirLine> Get();
        public void Update(AirLine airLine);
        public void Delete(string AirLineCode);
        public void Save();

    }
}
