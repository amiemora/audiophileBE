
using AudiophileBE.Entities;
using AudiophileBE.Models;

namespace AudiophileBE.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int userId);
    }
}
