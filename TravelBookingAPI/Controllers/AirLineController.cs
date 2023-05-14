using Microsoft.AspNetCore.Authorization;
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
        private readonly ApplicationDbContext _applicationDbContext;

        public AirLineController(IAirLineRepository airLineRepository, ApplicationDbContext applicationDbContext) {
            _airLineRepository=airLineRepository;
            _applicationDbContext=applicationDbContext;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var result = _airLineRepository.Get();
            return Ok(result);

        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(AirLine airLine) {
            var result = _applicationDbContext.AirLines.Find(airLine.AirLineCode);


            var result1 = _airLineRepository.Get().ToList();
            var result2 = result1.Where(x => x.AirLineCode==airLine.AirLineCode);
            if (result2.Any())
            {
                return Ok("AirLine already exists");
            }
                _airLineRepository.Create(airLine);
                _airLineRepository.Save();
            return Ok();
        }
        [HttpPut]
        [Authorize]
        public IActionResult Update(AirLine airLine) {
            _airLineRepository.Update(airLine);
            _airLineRepository.Save();
            return Ok(_airLineRepository.Get());    

        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string airLineCode)
        {
            _airLineRepository.Delete(airLineCode);
            _airLineRepository.Save();
            return Ok(_airLineRepository.Get());

        }
    }
}
