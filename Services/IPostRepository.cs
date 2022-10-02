using AudiophileBE.Entities;

namespace AudiophileBE.Services
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostAsync();
        Task<Post> GetPostAsync(int postId);
        Task<Post> CreatePostAsync(int userId, string songTitle, string album, string artist);
    }
}
