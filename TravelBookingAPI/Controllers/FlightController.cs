using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBookingAPI.Data;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository.IRepository;

namespace TravelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public FlightController(IFlightRepository flightRepository,ApplicationDbContext applicationDbContext)
        {
            _flightRepository=flightRepository;
            _applicationDbContext=applicationDbContext;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _flightRepository.Get();
            return Ok(result);

        }
        [HttpPost]
        public ActionResult Create(Flight flight)

        {
            var result=_applicationDbContext.AirLines.Find(flight.AirLineCode);
            if (result == null) {
                return Ok("AirLine not found");
            }


            _flightRepository.Create(flight);
            _flightRepository.Save();
            return Ok();

        }
        [HttpPut]
        public ActionResult Update(Flight flight)
        {
            _flightRepository.Update(flight);
            _flightRepository.Save();
            return Ok(_flightRepository.Get());
        }
        [HttpDelete]
        public ActionResult Delete(string flightCode)
        {
            _flightRepository.Delete(flightCode);
            _flightRepository.Save();
            return Ok(_flightRepository.Get());
        }

    }
}
