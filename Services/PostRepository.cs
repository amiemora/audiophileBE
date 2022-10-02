using AudiophileBE.DbContexts;
using AudiophileBE.Entities;
using AudiophileBE.Models;
using Microsoft.EntityFrameworkCore;

namespace AudiophileBE.Services
{
    public class PostRepository : IPostRepository
    {
        private readonly AudiophileContext _context;
        private readonly object _mapper;

        public PostRepository(AudiophileContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Post> CreatePostAsync(int userId, string songTitle, string album, string artist)
        {
            // Create a new Post
            var post = new Post();
            post.UserId = userId;
            post.SongTitle = songTitle;
            post.Album = album;
            post.Artist = artist;

            _context.Add(post);
            //return post;

            if (await _context.SaveChangesAsync() > 0)
            {
                return post;
            }
            else
            {
                return null;
            }
        }

            public async Task<IEnumerable<Post>> GetAllPostAsync()
        {
            return await _context.Post.ToListAsync();
        }

        public async Task<Post> GetPostAsync(int postId)
        {
            return await _context.Post.Where(c => c.PostId == postId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
