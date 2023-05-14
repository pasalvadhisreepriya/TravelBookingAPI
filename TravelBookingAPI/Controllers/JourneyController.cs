using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TravelBookingAPI.Data;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository.IRepository;

namespace TravelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public JourneyController(IJourneyRepository journeyRepository,ApplicationDbContext applicationDbContext)
        {
            _journeyRepository=journeyRepository;
            _applicationDbContext=applicationDbContext;
        }
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            var result = _journeyRepository.Get().ToList();
            
            return Ok(result);

        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(Journey journey)
        {
         
            var result = _applicationDbContext.Flights.Find(journey.FlightCode);
            if(result == null)
            {
                return Ok("Flight not found");
            }
            if (result.AirLineCode!=journey.AirLineCode)
            {
                return Ok("AirLine not found");
            }
            var result1 = _journeyRepository.Get().ToList();
          var result2=  result1.Where(x => (x.AirLineCode==journey.AirLineCode) &&(x.FlightCode==journey.FlightCode)&&(x.TravelDate==journey.TravelDate));
            if(result2.Any()) {
                return Ok("Flight already exists");
            }
            _journeyRepository.Create(journey);
            _journeyRepository.Save();
            return Ok();

        }
        [HttpPut]
        [Authorize]
        public ActionResult Update(Journey journey)
        {
            _journeyRepository.Update(journey);
            _journeyRepository.Save();
            return Ok(_journeyRepository.Get());
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
          
        {
            _journeyRepository.Delete(id);
            _journeyRepository.Save();
            return Ok(_journeyRepository.Get());
        }

    }
}
