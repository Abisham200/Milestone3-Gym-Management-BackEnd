using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;

namespace GymFeesManagement.IServices
{
    public interface IEnrollmentService
    {
        Task<List<Entrollment>> AddEnroll(EnrollRequest enrollRequest);
        Task<ICollection<Entrollment>> GetAllEnroll();

        Task<List<Entrollment>> EnrollmentByMember(int id);
        Task<string> DeleteEnroll(int id);
    }
}
