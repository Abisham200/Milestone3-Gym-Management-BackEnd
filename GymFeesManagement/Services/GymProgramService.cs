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

        public async Task<GymProgram> PostProgram(GymProgram program)
        {
            return await _gymProgramRepository.PostProgram(program);
        }

        public async Task<ICollection<GymProgram>> GetPrograms()
        {
            return await _gymProgramRepository.GetPrograms();
        }

        public async Task<GymProgram> GetProgram(int id)
        {
            return await _gymProgramRepository.GetProgram(id);
        }

        public async Task<GymProgram> PutProgram(GymProgram program, int id)
        {
            var getProgram = await _gymProgramRepository.GetProgram(id);

            if (getProgram != null)
            {
                return await _gymProgramRepository.PutProgram(program);
            }
            else {
                throw new Exception();
            }
            
        }
        public async Task<string> DeleteProgram(int id)
        {
            return await _gymProgramRepository.DeleteProgram(id);
        }
    }
}
