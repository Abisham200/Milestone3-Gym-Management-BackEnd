using System.ComponentModel.DataAnnotations;

namespace GymFeesManagement.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string NIC { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? MemberStatus { get; set; }
        public string? Address { get; set; }
        public string? ProfileImage { get; set; }
        public UserRoles Role { get; set; }
        public List<Entrollment> Entrollments { get; set; }



    }

    public enum UserRoles
    {
        Admin,
        Member
    }
    public enum Gender
    {
    Male,
    Female,
    Other
    }
}
