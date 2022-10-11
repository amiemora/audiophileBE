using AudiophileBE.Entities;

namespace AudiophileBE.Services
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostAsync();
        Task<Post> GetPostAsync(int postId);
        //Task<Post> CreatePostAsync(int userId, string songTitle, string album, string artist );
        //Task<Post> CreatePostAsync(Post post);
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
