using System.ComponentModel.DataAnnotations;

namespace GymFeesManagement.Entities
{
    public class Entrollment
    {
        [Key]
        public int Id { get; set; }
        public MemberDetail Member {  get; set; } 
        public int MemberId { get; set; }
        public GymProgram? Program {  get; set; }
        public int ProgramId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public Payment? Payment { get; set; }
       // public int PaymentId { get; set; }

    }
}
