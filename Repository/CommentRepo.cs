using Microsoft.EntityFrameworkCore;
using Projekt_WebAPI.Data;
using Projekt_WebAPI.Models;

namespace Projekt_WebAPI.Repository
{
    public class CommentRepo
    {
        private readonly TravelContext _context;

        public CommentRepo(TravelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comment>> AllComments()
        {
            var result = await _context.Comments.ToListAsync();

            return result;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);

            var result = await _context.SaveChangesAsync();

            return comment;
        }
        //public async Task<ICollection<Comment>> ShowUserComments()
        //{
        //    //var result = await _context.Comments.Where(x => x.Users.Name == Comment).ToListAsync();

        //    var result = await _context.Comments.Include(u => u.User.Comments)
        //        .ThenInclude(c => c.User.Name).ToListAsync();

        //    return result;

        //}
    }
}
