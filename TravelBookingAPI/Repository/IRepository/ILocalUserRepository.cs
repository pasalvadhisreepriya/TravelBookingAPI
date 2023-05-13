using TravelBookingAPI.Models;

namespace TravelBookingAPI.Repository.IRepository
{
    public interface ILocalUserRepository
    {
     
            bool IsUniqueUser(string username);
            Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
            Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO);
        }
    }

