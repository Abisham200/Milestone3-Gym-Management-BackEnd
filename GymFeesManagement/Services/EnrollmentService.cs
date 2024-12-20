﻿using GymFeesManagement.Database;
using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.DTOs.ResDTO;
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

        public async Task<List<Entrollment>> AddEnroll(EnrollRequest enrollRequest)
        {
            var enrollments = new List<Entrollment>();
            foreach (var programId in enrollRequest.Programs)
            {
                var enroll = new Entrollment
                {
                    UserId = enrollRequest.UserId,
                    ProgramId = programId,
                    CreatedDate = DateTime.Now,

                };
                enroll.DueDate = enroll.CreatedDate.AddDays(30);
                enrollments.Add(enroll);
            }



            var data = await _enrollmentRepository.AddEnroll(enrollments);
            return data;

        }

        public async Task<ICollection<Entrollment>> GetAllEnroll()
        {
            return await _enrollmentRepository.GetAllEnroll();
        }



        public async Task<List<Entrollment>> EnrollmentByMember(int id)
        {
            return await _enrollmentRepository.EnrollmentByMember(id);
        }


        public async Task<Message> DeleteEnroll(int id)
        {
            return await _enrollmentRepository.DeleteEnroll(id);
        }

        public async Task<ICollection<Entrollment>> GetAllDueEnroll(){
            return await _enrollmentRepository.GetAllDueEnroll();
        }
    }
}
