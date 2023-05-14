using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository;
using TravelBookingAPI.Repository.IRepository;

namespace TravelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;
        protected APIResponse _response;

        public UserController(IUserRepository UserRepository)
        {
            _UserRepository=UserRepository;
            _response = new();
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _UserRepository.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO model)
        {
            bool ifUserNameUnique = _UserRepository.IsUniqueUser(model.UserName);
            if (!ifUserNameUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }

            var user = await _UserRepository.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var result = _UserRepository.Get();
            return Ok(result);

        }
       
        [HttpPut]
        [Authorize]
        public IActionResult Update(User user)
        {
            _UserRepository.Update(user);
            _UserRepository.Save();
            return Ok(_UserRepository.Get());

        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string Email)
        {
            _UserRepository.Delete(Email);
            _UserRepository.Save();
            return Ok(_UserRepository.Get());

        }
    }
}
