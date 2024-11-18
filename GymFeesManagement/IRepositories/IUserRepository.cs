using GymFeesManagement.Entities;

namespace GymFeesManagement.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(User user);
        Task<User> Register(User user);
        Task<string> DeleteUser(int id);
        Task<User> GetUserByEmail(string email);
    }
}
