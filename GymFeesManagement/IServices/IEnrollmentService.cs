using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;

namespace GymFeesManagement.IServices
{
    public interface IEnrollmentService
    {
        Task<Entrollment> AddEnroll(EnrollRequest enrollRequest);
    }
}
