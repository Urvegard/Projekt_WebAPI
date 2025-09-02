using Projekt_WebAPI.Models;
using Projekt_WebAPI.Repository;

namespace Projekt_WebAPI.Services
{
    public class CommentService
    {
        private readonly CommentRepo _repo;

        public CommentService(CommentRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Comment>> AllComments()
        {
            var result = await _repo.AllComments();

            return result;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            var result = await _repo.AddComment(comment);

            return result;
        }
    }
}
