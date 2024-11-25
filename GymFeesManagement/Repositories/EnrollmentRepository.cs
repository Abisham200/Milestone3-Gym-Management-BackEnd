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

        public async Task<Entrollment> AddEnroll(Entrollment entrollment)
        {
            var data = await _appDbContext.Entrollments.AddAsync(entrollment);
            await _appDbContext.SaveChangesAsync();

            return data.Entity;
        }

        public async Task<ICollection<Entrollment>> GetAllEnroll()
        { 
          return await _appDbContext.Entrollments.ToListAsync();
        }

        public async Task<Entrollment> EnrollmentByMember(int id)
        { 
        var enroll = await _appDbContext.Entrollments.SingleOrDefaultAsync(d => d.UserId == id );
            if (enroll == null)
            {
                throw new Exception();
            }

            return enroll;
        }
    }
}
