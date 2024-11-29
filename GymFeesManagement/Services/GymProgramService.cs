using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.DTOs.ResDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;
using GymFeesManagement.IServices;

namespace GymFeesManagement.Services
{
    public class GymProgramService : IGymProgramService
    {
        private readonly IGymProgramRepository _gymProgramRepository; 
        public GymProgramService(IGymProgramRepository gymProgramRepository)
        { 
            _gymProgramRepository = gymProgramRepository;
        }

        public async Task<GymProgram> PostProgram(ProgramRequestDTO programRequest)
        {
           
                var response = new GymProgram
                {
                    Name = programRequest.Name,
                    Description = programRequest.Description,
                    Programstatus = programRequest.ProgramStatus,
                    CreatedDate = programRequest.CreatedDate,
                    PricePerMonth = programRequest.PricePerMonth,
                   
                };
                var data = await _gymProgramRepository.NewProgram(response);
                return data;
           

        }

        public async Task<ICollection<GymProgram>> GetPrograms()
        {
            return await _gymProgramRepository.GetPrograms();
        }

        public async Task<GymProgram> GetProgram(int id)
        {
            return await _gymProgramRepository.GetProgram(id);
        }

       


        public async Task<ProgramResponseDTO> UpdateProgram(ProgramRequestDTO programDTO, int id)
        {

            var getProgram = await _gymProgramRepository.GetProgram(id);



            getProgram.Name = programDTO.Name;
            getProgram.Description = programDTO.Description;
            getProgram.Programstatus = programDTO.ProgramStatus;
            getProgram.PricePerMonth = programDTO.PricePerMonth;
           

            var check = await _gymProgramRepository.UpdateProgram(getProgram);

            var res = new ProgramResponseDTO
            {
                Id = id,
                Name = check.Name,
                Description = check.Description,
                CreatedDate = check.CreatedDate,
            };
            return res;
        }


        public async Task<string> DeleteProgram(int id)
        {
            return await _gymProgramRepository.DeleteProgram(id);
        }
    }
}
