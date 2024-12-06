using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.DTOs.ResDTO;
using GymFeesManagement.Entities;

namespace GymFeesManagement.IServices
{
    public interface IUserService
    {
        Task<ICollection<User>> GetUsers(UserRoles? role);
        Task<User> GetUser(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> UpdateUser(int id, UserRequest userRequest);
        Task<string> DeleteUser(int id);
        Task<User> Register(UserRequest userRequest);
        Task<TokenModel> LogIn(Login loginData);

        Task<ICollection<RoleResponse>> GetRoles();
    }
}
