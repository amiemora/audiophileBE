



using AudiophileBE.DbContexts;
using AudiophileBE.Entities;
using AudiophileBE.Models;
using Microsoft.EntityFrameworkCore;

namespace AudiophileBE.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AudiophileContext _context;

        public UserRepository(AudiophileContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _context.Users.Where(c => c.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
