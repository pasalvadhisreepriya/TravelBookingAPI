using Azure.Identity;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelBookingAPI.Data;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository.IRepository;

namespace TravelBookingAPI.Repository
{
    public class LocalUserRepository : ILocalUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private string secretKey;

        public LocalUserRepository(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext=applicationDbContext;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string username)
        {
            var user = _applicationDbContext.LocalUsers.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        
    }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
                var user = _applicationDbContext.LocalUsers
                    .FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower()
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
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
                {
                    Token = tokenHandler.WriteToken(token),
                    User =user,

                };
                return loginResponseDTO;
            }

        public async Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            LocalUser user = new LocalUser();
            {
                string UserName = registerationRequestDTO.UserName;
                string Password = registerationRequestDTO.Password;
                string Name = registerationRequestDTO.Name;
                string Role = registerationRequestDTO.Role;
            };
            _applicationDbContext.LocalUsers.Add(user);
            await _applicationDbContext.SaveChangesAsync();
            user.Password = "";
            return user;

        }
    }

       
    }

