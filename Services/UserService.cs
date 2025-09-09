using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.DTOs;
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

        // Skapar en ny "User Entity",(ny användare), via DTO:n.
        // Bra för att kontrollera känslig data.
        public async Task<User> AddUser(CreateUserDTO user)
        {
            var UserToInsert = new User
            {
                Name = user.Name,
                SurName = user.SurName
            };

            var result = await _repo.AddUser(UserToInsert);

            return result;
        }
        public async Task<User> GetUserById(int userID)
        {
            var result = await _repo.GetUserById(userID); 

            return result;
        }
    }
}
