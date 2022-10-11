using AudiophileBE.Entities;
using AudiophileBE.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AudiophileBE.Services
{
    public class PostRepository : IPostRepository
    {
        private readonly AudiophileContext _context;
        private readonly ILogger<PostRepository> _logger;

        public PostRepository(AudiophileContext context, ILogger<PostRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAllPostAsync()
        {
            return await _context.Post.ToListAsync();
        }

        public async Task<Post> GetPostAsync(int postId)
        {
            return await _context.Post.Where(c => c.PostID == postId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
