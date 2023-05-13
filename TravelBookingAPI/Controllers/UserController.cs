using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository;
using TravelBookingAPI.Repository.IRepository;

namespace TravelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        [HttpGet]
        public ActionResult Get() {
           var result= _userRepository.Get();
            return Ok(result);

        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            _userRepository.Create(user);
            _userRepository.Save();
            return Ok();

        }
        [HttpPut]
        public ActionResult Update(User user)
        {
            _userRepository.Update(user);
            _userRepository.Save();
            return Ok(_userRepository.Get());
        }
        [HttpDelete]
        public ActionResult Delete(string email) {
            _userRepository.Delete(email);
            _userRepository.Save();
            return Ok(_userRepository.Get());
        }


    }
}
