using PRN231.Entities;
using PRN231.Repositories;
using PRN231.Requests;

namespace PRN231.Services.Impl
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ActiveUserAsync(int id)
        {
            return await _userRepository.ActiveUser(id);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return true;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByUsernameAndPassword(Login login)
        {
            return await _userRepository.GetUserByUsernameAndPassword(login);
        }

        public async Task<List<User>> GetUsersAsync(string search)
        {
            return await _userRepository.GetUsers(search);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}
