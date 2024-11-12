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
        public MemberDetail? Member {  get; set; }
        public int MemberId { get; set; }
    }
}
