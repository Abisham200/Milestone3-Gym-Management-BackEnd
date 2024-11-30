using GymFeesManagement.Database;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GymFeesManagement.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public EnrollmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Entrollment>> AddEnroll(List<Entrollment> enrollments)
        {
             await _appDbContext.Entrollments.AddRangeAsync(enrollments);
            await _appDbContext.SaveChangesAsync();

            return enrollments;
        }

        public async Task<ICollection<Entrollment>> GetAllEnroll()
        { 
          return await _appDbContext.Entrollments.Include(e => e.user).Include(e => e.Program).ToListAsync();
        }

        public async Task<List<Entrollment>> EnrollmentByMember(int id)
        { 
            var data = await _appDbContext.Entrollments.Where(e => e.UserId == id).ToListAsync();   
            return data;
        }

        public async Task<string> DeleteEnroll(int id)
        {
            var enroll = await _appDbContext.Entrollments.FindAsync(id);
            if (enroll == null)
            {
                throw new ArgumentException();
            }

            _appDbContext.Entrollments.Remove(enroll);
            await _appDbContext.SaveChangesAsync();

            return "Enrollment Successfully Deleted...";
        }
    }
}
