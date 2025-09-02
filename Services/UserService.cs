using Projekt_WebAPI.Models;
using Projekt_WebAPI.Repository;

namespace Projekt_WebAPI.Services
{
    public class UserService
    {
        private readonly UserRepo _repo;

        public UserService(UserRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<User>> AllUsers()
        {
            var result = await _repo.AllUsers();

            return result;
        }

        public async Task<User> AddUser(User user)
        {
            var result = await _repo.AddUser(user);

            return result;
        }
    }

}
