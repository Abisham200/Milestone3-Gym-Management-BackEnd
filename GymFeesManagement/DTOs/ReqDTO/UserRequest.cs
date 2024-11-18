using GymFeesManagement.Entities;
using System.ComponentModel.DataAnnotations;

namespace GymFeesManagement.DTOs.ReqDTO
{
    public class UserRequest
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public string NIC { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string? Address { get; set; }
        public UserRoles Role { get; set; }
    }
}
