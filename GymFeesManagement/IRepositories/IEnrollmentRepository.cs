using GymFeesManagement.Entities;

namespace GymFeesManagement.IRepositories
{
    public interface IEnrollmentRepository
    {
        Task<Entrollment> AddEnroll(Entrollment entrollment);
    }
}
