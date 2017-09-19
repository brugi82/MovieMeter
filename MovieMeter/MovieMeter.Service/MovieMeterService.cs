using MovieMeter.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Model;
using MovieMeter.Repository.Contracts;

namespace MovieMeter.Service
{
    public class MovieMeterService : IMovieMeterService
    {
        public MovieMeterService(IMovieMeterRepository repository, IProgramProvider provider)
        {
            if(repository == null)
                throw new ArgumentNullException(nameof(repository));
            if(provider == null)
                throw new ArgumentNullException(nameof(provider));

            Repository = repository;
            ProgramProvider = provider; 
        }

        public IMovieMeterRepository Repository { get; private set; }
        public IProgramProvider ProgramProvider { get; private set; }

        public async Task CreateUpdate(string sourceId)
        {
            var source = await Repository.GetSource(sourceId);
            Update newUpdate = new Update()
            {
                UpdatedOn = DateTime.Now
            };
            var programs = await ProgramProvider.GetPrograms(source.ParserId);
            await Repository.AddUpdate(newUpdate, programs, sourceId);
            
        }

        public async Task<List<Program>> GetAllPrograms(ProgramQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Source>> GetAllSources()
        {
            return await Repository.GetAllSources();
        }

        public async Task<List<Update>> GetAllUpdates()
        {
            return await Repository.GetAllUpdates();
        }

        public async Task<Update> GetLatestUpdateForSource(string sourceId)
        {
            return await Repository.GetLatestUpdateForSource(sourceId);
        }

        public Task<Program> GetProgram(string programId)
        {
            throw new NotImplementedException();
        }

        public async Task<Source> GetSource(string sourceId)
        {
            return await Repository.GetSource(sourceId);
        }

        public async Task<List<Update>> GetUpdatesForSource(string sourceId)
        {
            return await Repository.GetUpdatesForSource(sourceId);
        }

        public async Task HarvestMovieData()
        {
            var programs = await ProgramProvider.GetPrograms(-1);

        }

        public Task UpdateProgram(Program program)
        {
            throw new NotImplementedException();
        }
    }
}
