using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.DTOs.ResDTO;
using GymFeesManagement.Entities;

namespace GymFeesManagement.IServices
{
    public interface IGymProgramService
    {
        Task<GymProgram> PostProgram(ProgramRequestDTO programRequest);
        Task<ICollection<GymProgram>> GetPrograms();
        Task<GymProgram> GetProgram(int id);
        
        Task<ProgramResponseDTO> UpdateProgram(ProgramRequestDTO programDTO, int id);
        Task<Message> DeleteProgram(int id);

    }    
}
