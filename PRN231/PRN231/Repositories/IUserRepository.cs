using PRN231.Entities;
using PRN231.Requests;

namespace PRN231.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUserByUsernameAndPassword(Login login);
        Task<List<User>> GetUsers(string search);
        Task<bool> ActiveUser(int id);
        Task<User> GetUserById(int id);
    }
}
