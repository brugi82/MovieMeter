using MovieMeter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Repository.Contracts
{
    public interface IMovieMeterRepository
    {
        Task<List<Program>> GetAllPrograms(ProgramQuery query);
        Task<List<Update>> GetAllUpdates();
        Task<List<Update>> GetUpdatesForSource(string sourceId);
        Task<Update> GetLatestUpdateForSource(string sourceId);
        Task<List<Source>> GetAllSources();
        Task<Source> GetSource(string sourceId);

        Task<Program> AddOrUpdateProgram(Program program);
        Task UpdateProgram(Program program);
        Task<Program> GetProgram(string programId);

        Task AddOrUpdateProgramUserData(ProgramUserData programUserData);
        Task AddUpdate(Update update, List<Program> programs, string sourceId);
    }
}
