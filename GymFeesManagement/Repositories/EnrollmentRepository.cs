using GymFeesManagement.Database;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;

namespace GymFeesManagement.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public EnrollmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Entrollment> AddEnroll(Entrollment entrollment)
        {
            var data = await _appDbContext.Entrollments.AddAsync(entrollment);
            await _appDbContext.SaveChangesAsync();

            return data.Entity;
        }
    }
}
