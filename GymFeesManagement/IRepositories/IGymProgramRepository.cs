using GymFeesManagement.Entities;

namespace GymFeesManagement.IRepositories
{
    public interface IGymProgramRepository
    {
        Task<GymProgram> PostProgram(GymProgram program);
        Task<GymProgram> GetProgram(int id);
        Task<ICollection<GymProgram>> GetPrograms();
        Task<GymProgram> PutProgram(GymProgram program);
        Task<string> DeleteProgram(int id);

    }
}
