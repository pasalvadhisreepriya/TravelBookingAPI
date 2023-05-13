using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TravelBookingAPI.Data;
using TravelBookingAPI.Models;
using TravelBookingAPI.Repository.IRepository;

namespace TravelBookingAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
        }
        public void Create(User user)
        {
            _applicationDbContext.Users.Add(user);

        }

        public void Delete(string email)
        {
          User user=  _applicationDbContext.Users.Find(email);
            _applicationDbContext.Users.Remove(user);
        }

        public IEnumerable<User> Get()
        {
           
            return _applicationDbContext.Users.ToList();
        }

        public  void Update(User user)
        {
            _applicationDbContext.Users.Update(user);
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
