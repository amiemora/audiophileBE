using AudiophileBE.DbContexts;
using AudiophileBE.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudiophileBE.Services
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AudiophileContext _context;
        private readonly object _mapper;

        public CommentRepository(AudiophileContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Comment> CreateCommentAsync(int postId, int userId, string commentBody)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment> GetCommentAsync(int commentId)
        {
            return await _context.Comment.Where(c => c.CommentId == commentId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
