using System.ComponentModel.DataAnnotations;

namespace GymFeesManagement.Entities
{
    public class MemberDetail
    {
        
        public int Id { get; set; }
       
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string PasswordHashed { get; set; }
       
        public string ContactNumber { get; set; }

        
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
       
       

    }

    
}
