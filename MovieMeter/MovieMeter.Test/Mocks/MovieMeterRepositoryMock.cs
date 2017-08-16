using MovieMeter.Model;
using MovieMeter.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Test.Mocks
{
    public class MovieMeterRepositoryMock : IMovieMeterRepository
    {
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
