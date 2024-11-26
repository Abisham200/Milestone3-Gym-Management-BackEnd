namespace GymFeesManagement.DTOs.ReqDTO
{
    public class ProgramRequestDTO
    {
        public string Name { get; set; }
        public decimal PricePerMonth { get; set; }
        public string Description { get; set; }
        public bool ProgramStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
