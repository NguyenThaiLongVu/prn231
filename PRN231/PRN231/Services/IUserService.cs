using PRN231.Entities;
using PRN231.Requests;

namespace PRN231.Services
{
    public interface IUserService
    {
        Task<User> GetUserByUsernameAndPassword(Login login);
        Task<List<User>> GetUsersAsync(string search);
        Task<bool> ActiveUserAsync(int id);
        Task<User> GetUserByIdAsync(int id);
        Task<bool> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
    }
}
