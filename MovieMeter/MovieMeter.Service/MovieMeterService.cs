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
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            ProgramProvider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public IMovieMeterRepository Repository { get; private set; }
        public IProgramProvider ProgramProvider { get; private set; }

        public async Task<List<Program>> GetAllPrograms()
        {
            return await Repository.GetAllPrograms();
        }

        public async Task HarvestMovieData()
        {
            var programs = await ProgramProvider.GetPrograms();

        }
    }
}
