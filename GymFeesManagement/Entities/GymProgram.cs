using System.ComponentModel.DataAnnotations;

namespace GymFeesManagement.Entities
{
    public class GymProgram
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Programstatus { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
