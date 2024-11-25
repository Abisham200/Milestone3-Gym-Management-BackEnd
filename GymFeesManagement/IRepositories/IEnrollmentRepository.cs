using GymFeesManagement.Entities;

namespace GymFeesManagement.IRepositories
{
    public interface IEnrollmentRepository
    {
        Task<Entrollment> AddEnroll(Entrollment entrollment);
        Task<ICollection<Entrollment>> GetAllEnroll();
        Task<Entrollment> EnrollmentByMember(int id);
    }
}
