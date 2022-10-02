using AudiophileBE.Entities;

namespace AudiophileBE.Services
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllCommentAsync();
        Task<Comment> GetCommentAsync(int commentId);
        Task<Comment> CreateCommentAsync(int postId, int userId, string commentBody);
    }
}
