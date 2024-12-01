using System.ComponentModel.DataAnnotations;

namespace GymFeesManagement.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Entrollment? Entrollment { get; set; }
        public int EntrollmentId { get; set; }
    }
}
