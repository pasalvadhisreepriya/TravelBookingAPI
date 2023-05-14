using TravelBookingAPI.Data;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TravelBookingAPI.Repository
{
    public class AirLineRepository : IAirLineRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
       

        public AirLineRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
        }

        public void Create(AirLine airLine)
        {
            _applicationDbContext.AirLines.Add(airLine);
        }

        public void Delete(string airLineCode)
        {
            AirLine airLine = _applicationDbContext.AirLines.Find(airLineCode);
            _applicationDbContext.AirLines.Remove(airLine);
        }

        public IEnumerable<AirLine> Get()
        {
            return _applicationDbContext.AirLines.ToList();
        }



        public void Update(AirLine airLine)
        {
            _applicationDbContext.AirLines.Update(airLine);
        }
        public void Save()
        {

            _applicationDbContext.SaveChanges();

        }

    }
}
