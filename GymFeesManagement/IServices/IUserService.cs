using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;

namespace GymFeesManagement.IServices
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> UpdateUser(User user, int id);
        Task<string> DeleteUser(int id);
        Task<User> Register(UserRequest userRequest);
        Task<TokenModel> LogIn(Login loginData);
    }
}
