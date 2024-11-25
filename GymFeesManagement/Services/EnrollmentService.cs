using GymFeesManagement.Database;
using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;
using GymFeesManagement.IServices;
using GymFeesManagement.Repositories;

namespace GymFeesManagement.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Entrollment> AddEnroll(EnrollRequest enrollRequest)
        {
            var enroll = new Entrollment
            {
               UserId = enrollRequest.UserId,
               ProgramId = enrollRequest.ProgramId,
               CreatedDate = enrollRequest.CreatedDate,
               DueDate = enrollRequest.DueDate,
            };

            return await _enrollmentRepository.AddEnroll(enroll);

        }

        public async Task<ICollection<Entrollment>> GetAllEnroll()
            { 
            return await _enrollmentRepository.GetAllEnroll();
            }

        public async Task<Entrollment> EnrollmentByMember(int id)
        {
            return await _enrollmentRepository.EnrollmentByMember(id);
        }
    }
}
