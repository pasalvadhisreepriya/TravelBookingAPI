using Microsoft.AspNetCore.Mvc;
using TravelBookingAPI.Models;

namespace TravelBookingAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        public void Create(User user);
        public void Update(User user);
        public void Delete(string email);   
        public IEnumerable<User> Get();
        public void Save();
    }
}
