using GymFeesManagement.Entities;

namespace GymFeesManagement.IRepositories
{
    public interface IEnrollmentRepository
    {
        Task<List<Entrollment>> AddEnroll(List<Entrollment> enrollments);
        Task<ICollection<Entrollment>> GetAllEnroll();
        Task<List<Entrollment>> EnrollmentByMember(int id);
        Task<string> DeleteEnroll(int id);
        Task<ICollection<Entrollment>> GetAllDueEnroll();
    }
}
