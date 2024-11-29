using GymFeesManagement.Entities;

namespace GymFeesManagement.DTOs.ReqDTO
{
    public class EnrollRequest
    {
       
        public int UserId { get; set; }
        public List<int> Programs { get; set; }
      //  public DateTime CreatedDate { get; set; }
      //  public DateTime DueDate { get; set; }
        
    }
}
