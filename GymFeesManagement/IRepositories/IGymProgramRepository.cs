using GymFeesManagement.DTOs.ResDTO;
using GymFeesManagement.Entities;

namespace GymFeesManagement.IRepositories
{
    public interface IGymProgramRepository
    {
        Task<GymFeesManagement.Entities.GymProgram> NewProgram(GymFeesManagement.Entities.GymProgram program);
        Task<GymProgram> GetProgram(int id);
        Task<ICollection<GymProgram>> GetPrograms();
        Task<GymProgram> UpdateProgram(GymProgram Program);
        Task<Message> DeleteProgram(int id);

    }
}
