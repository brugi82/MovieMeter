using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model.Contracts
{
    public interface IMovieMeterService
    {
        Task<List<Program>> GetAllPrograms(ProgramQuery query, int count);
        Task<List<Update>> GetAllUpdates();
        Task<List<Update>> GetUpdatesForSource(string sourceId);
        Task<Update> GetLatestUpdateForSource(string sourceId);
        Task<List<Source>> GetAllSources();
        Task<Source> GetSource(string sourceId);
        Task<Program> GetProgram(string programId);
        Task UpdateProgram(Program program);
        Task<int> GetActiveProgramCount();

        Task CreateUpdate(string sourceId);
    }
}
