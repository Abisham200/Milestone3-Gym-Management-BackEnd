using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;
using GymFeesManagement.IServices;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<User> UpdateUser(User user, int id)
        {
            return await _userRepository.UpdateUser(user);
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
    }
}
