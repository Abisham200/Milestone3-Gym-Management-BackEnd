using GymFeesManagement.Entities;

namespace GymFeesManagement.IRepositories
{
    public interface IEnrollmentRepository
    {
        Task<List<Entrollment>> AddEnroll(List<Entrollment> enrollments);
        Task<ICollection<Entrollment>> GetAllEnroll();
        Task<List<Entrollment>> EnrollmentByMember(int id);
    }
}
