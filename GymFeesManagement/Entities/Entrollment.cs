using System.ComponentModel.DataAnnotations;

namespace GymFeesManagement.Entities
{
    public class Entrollment
    {
        [Key]
        public int Id { get; set; }
        public User user {  get; set; } 
        public int UserId { get; set; }     
        public int ProgramId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public Payment? Payment { get; set; }
       // public int PaymentId { get; set; }

    }
}
