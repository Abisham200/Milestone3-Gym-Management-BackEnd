using System.ComponentModel.DataAnnotations;

namespace GymFeesManagement.Entities
{
    public class SkippedPayment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Reason { get; set; }
        public User? user {  get; set; }
        public int UserId { get; set; }
    }
}
