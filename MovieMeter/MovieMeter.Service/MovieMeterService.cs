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

        public Task<List<Program>> GetAllPrograms()
        {
            throw new NotImplementedException();
        }

        public Task HarvestMovieData()
        {
            throw new NotImplementedException();
        }
    }
}
