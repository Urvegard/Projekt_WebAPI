using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Data;
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
