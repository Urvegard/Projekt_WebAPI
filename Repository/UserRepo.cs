using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Controllers;
using Projekt_WebAPI.Data;
using Projekt_WebAPI.DTOs;
using Projekt_WebAPI.Models;

namespace Projekt_WebAPI.Repository
{
    public class UserRepo
    {
        private readonly TravelContext _context;

        public UserRepo(TravelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> AllUsers()
        {
            var result = await _context.Users.ToListAsync();

            return result;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);

            var result = await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserById(int userID)
        {
            var result = await _context.Users.FindAsync(userID);

            return result;
        }
        public async Task<ICollection<UserWithCommentsDTO>> ShowUserWithComments()
        {
            var result = await _context.Users.Include(u => u.Comments).ThenInclude(c => c.Attraction)
                .ToListAsync();

            var users = new List<UserWithCommentsDTO>();

            foreach (var user in result)
            {
                //Kommer att visa användarens kommentarer samt vilken sevärdhet den är skriven på.

                var userDTO = new UserWithCommentsDTO
                {
                    Name = user.Name,
                    SurName = user.SurName,
                    Comments = user.Comments
                    .Select(c => new CommentsDTO
                    {
                        Text = c.Text,
                        AttractionName = c.Attraction?.Name   
                    })
                    .ToList()
                };
                users.Add(userDTO);
            }
            return users;
        }
    }
}
