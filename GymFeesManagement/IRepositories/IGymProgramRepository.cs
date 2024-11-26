using GymFeesManagement.Entities;

namespace GymFeesManagement.IRepositories
{
    public interface IGymProgramRepository
    {
        Task<GymFeesManagement.Entities.GymProgram> NewProgram(GymFeesManagement.Entities.GymProgram program);
        Task<GymProgram> GetProgram(int id);
        Task<ICollection<GymProgram>> GetPrograms();
        Task<GymProgram> UpdateProgram(GymProgram Program);
        Task<string> DeleteProgram(int id);

    }
}
