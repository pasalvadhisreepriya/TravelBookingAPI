using TravelBookingAPI.Models;

namespace TravelBookingAPI.Repository.IRepository
{
    public interface IUserRepository
    {
      
        public IEnumerable<User> Get();
        public void Update(User user);
        public void Delete(string Email);
        public void Save();

        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<User> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}

