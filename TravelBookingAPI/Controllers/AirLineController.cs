using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBookingAPI.Data;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository;
using TravelBookingAPI.Repository.IRepository;

namespace TravelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirLineController : ControllerBase
    {
        private readonly IAirLineRepository _airLineRepository;

        public AirLineController(IAirLineRepository airLineRepository) {
            _airLineRepository=airLineRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var a = _airLineRepository.Get();
            return Ok(a);

        }
        [HttpPost]  
        public IActionResult Create(AirLine airLine) {
            _airLineRepository.Create(airLine);
                _airLineRepository.Save();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(AirLine airLine) {
            _airLineRepository.Update(airLine);
            _airLineRepository.Save();
            return Ok(_airLineRepository.Get());    

        }
        [HttpDelete]
        public IActionResult Delete(string airLineCode)
        {
            _airLineRepository.Delete(airLineCode);
            _airLineRepository.Save();
            return Ok(_airLineRepository.Get());

        }
    }
}
