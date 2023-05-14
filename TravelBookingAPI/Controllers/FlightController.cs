using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TravelBookingAPI.Data;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository;
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
        [Authorize]
        public ActionResult Get()
        {
            var result = _flightRepository.Get();
            return Ok(result);

        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(Flight flight)

        {
            var result=_applicationDbContext.AirLines.Find(flight.AirLineCode);
            if (result == null) {
                return Ok("AirLine not found");
            }


            var result1 = _flightRepository.Get().ToList();
            var result2 = result1.Where(x => x.FlightCode==flight.FlightCode);
            if (result2.Any())
            {
                return Ok("Flight already exists");
            }


            _flightRepository.Create(flight);
            _flightRepository.Save();
            return Ok();

        }
        [HttpPut]
        [Authorize]
        public ActionResult Update(Flight flight)
        {
            _flightRepository.Update(flight);
            _flightRepository.Save();
            return Ok(_flightRepository.Get());
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(string flightCode)
        {
            _flightRepository.Delete(flightCode);
            _flightRepository.Save();
            return Ok(_flightRepository.Get());
        }

    }
}
