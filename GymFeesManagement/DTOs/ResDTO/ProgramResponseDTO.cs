using System.ComponentModel.DataAnnotations;

namespace GymFeesManagement.DTOs.ResDTO
{
    public class ProgramResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerMonth { get; set; }
        public string Description { get; set; }
        public bool Programstatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
