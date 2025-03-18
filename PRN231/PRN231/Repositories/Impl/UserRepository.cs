using Microsoft.EntityFrameworkCore;
using PRN231.Entities;
using PRN231.Requests;

namespace PRN231.Repositories.Impl
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<bool> ActiveUser(int id)
        {
            User user = await GetUserById(id);
            user.Status = true;
            _context.Update(user);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstAsync(u => u.UserID == id);
        }

        public async Task<User> GetUserByUsernameAndPassword(Login login)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username && u.PasswordHash == login.Password);
        }

        public async Task<List<User>> GetUsers(string search)
        {
            return await _context.Users.Where(u => u.Username.Contains(search)).ToListAsync();
        }
    }
}
