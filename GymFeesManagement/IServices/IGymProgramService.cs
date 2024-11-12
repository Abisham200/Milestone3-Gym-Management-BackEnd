using GymFeesManagement.Entities;

namespace GymFeesManagement.IServices
{
    public interface IGymProgramService
    {
        Task<GymProgram> PostProgram(GymProgram program);
        Task<ICollection<GymProgram>> GetPrograms();
        Task<GymProgram> GetProgram(int id);
        Task<GymProgram> PutProgram(GymProgram program, int id);
        Task<string> DeleteProgram(int id);

    }    
}
