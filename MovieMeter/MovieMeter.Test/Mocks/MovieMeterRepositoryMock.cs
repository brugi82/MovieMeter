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
        public bool GetAllProgramsCalled { get; internal set; }

        public Task<List<Program>> GetAllPrograms()
        {
            GetAllProgramsCalled = true;

            return Task.Run(() => new List<Program>());
        }

        public Task HarvestMovieData()
        {
            throw new NotImplementedException();
        }
    }
}
