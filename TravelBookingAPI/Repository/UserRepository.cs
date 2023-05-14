
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelBookingAPI.Data;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository.IRepository;

namespace TravelBookingAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        private string secretKey;

        public UserRepository(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext=applicationDbContext;
           
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

      

        public bool IsUniqueUser(string email)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return true;
            }
            return false;
        
    }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
                var user = _applicationDbContext.Users.FirstOrDefault(u => u.Email.ToLower() == loginRequestDTO.UserName.ToLower()
                    && u.Password == loginRequestDTO.Password);

                if (user == null)
                {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };

                }

                //if user was found generate JWT Token
                
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user

            };
                return loginResponseDTO;
            }

        public async Task<User> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            User user = new User()
            {
                Email = registerationRequestDTO.UserName,
                Password = registerationRequestDTO.Password,
                Name = registerationRequestDTO.Name,
                Role = registerationRequestDTO.Role
            };
            _applicationDbContext.Users.Add(user);
            await _applicationDbContext.SaveChangesAsync();
            user.Password="";
            return user;
        }
        public void Delete(string Email)
        {
            User user = _applicationDbContext.Users.Find(Email);
            _applicationDbContext.Users.Remove(user);
        }

        public IEnumerable<User> Get()
        {
            return _applicationDbContext.Users.ToList();
        }

       

        public void Update(User user)
        {
            _applicationDbContext.Users.Update(user); 
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }

       
    }

