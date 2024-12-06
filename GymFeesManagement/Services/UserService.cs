using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.DTOs.ResDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;
using GymFeesManagement.IServices;
using GymFeesManagement.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymFeesManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<ICollection<User>> GetUsers(UserRoles? role)
        {
            return await _userRepository.GetUsers(role);
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<User> UpdateUser(int id, UserRequest userRequest)
        {
           var getUser = await _userRepository.GetUser(id);

            getUser.FirstName = userRequest.FirstName;
            getUser.LastName = userRequest.LastName;
            getUser.ContactNumber = userRequest.ContactNumber;
            getUser.Email = userRequest.Email;
            getUser.NIC = userRequest.NIC;
            getUser.Age = userRequest.Age;
            getUser.Gender = userRequest.Gender;
            getUser.Height = userRequest.Height;
            getUser.Weight = userRequest.Weight;
            getUser.Address = userRequest.Address;
            getUser.ProfileImage = userRequest.ProfileImage;
            getUser.Role = userRequest.Role;

            var check = await _userRepository.UpdateUser(getUser);

            var user = new User
            {
                Id = id,
                FirstName = check.FirstName,
                LastName = check.LastName,
                ContactNumber = check.ContactNumber,
                Email = check.Email,
                NIC = check.NIC,
                Age = check.Age,
                Gender = check.Gender,
                Height = check.Height,
                Weight = check.Weight,
                Address = check.Address,
                ProfileImage = check.ProfileImage,
                Role = check.Role,

            };
             return user;
        }

        public async Task<string> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<User> Register(UserRequest userRequest)
        {
            var user = new User
            {
                
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                NIC = userRequest.NIC,
                ContactNumber = userRequest.ContactNumber,
                Address = userRequest.Address,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password),
                CreationDate = DateTime.Now,
                MemberStatus = true,
                Age = userRequest.Age,
                ProfileImage = userRequest.ProfileImage,
                Gender = userRequest.Gender,
                Height = userRequest.Height,
                Weight = userRequest.Weight,
                Role = userRequest.Role,


            };
            return await _userRepository.Register(user);
        }

        public async Task<TokenModel> LogIn(Login loginData)
        {

            var user = await _userRepository.GetUserByEmail(loginData.Email);
            var hash = BCrypt.Net.BCrypt.Verify(loginData.Password, user.PasswordHash);
            if (hash)
            {
                var token = CreateToken(user);
                return token;
            }
            else
            {
                throw new Exception("Invalid Password");
            }
        }

        private TokenModel CreateToken(User user)
        {
            var claimsList = new List<Claim>();
            claimsList.Add(new Claim("Id", user.Id.ToString()));
            claimsList.Add(new Claim("FirstName", user.FirstName));
            claimsList.Add(new Claim("LastName", user.LastName));
            claimsList.Add(new Claim("Email", user.Email));
            claimsList.Add(new Claim("ContactNo", user.ContactNumber));
            claimsList.Add(new Claim("NICNumber", user.NIC));
            claimsList.Add(new Claim("Role", user.Role.ToString()));
            

            var key = _configuration["JWT:Key"];
            var secKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claimsList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials
                );
            var response = new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return response;
        }

        public async Task<ICollection<RoleResponse>> GetRoles()
        {
            var dict = new Dictionary<int, string>();
            foreach (var name in Enum.GetNames(typeof(UserRoles)))
            {
                dict.Add((int)Enum.Parse(typeof(UserRoles), name), name);
            }
            var roles = new List<RoleResponse>();
            foreach (var item in dict)
            {
                var role = new RoleResponse
                {
                    Key = item.Key,
                    Value = item.Value
                };
                roles.Add(role);
            }
            return roles;
        }
    }
}
