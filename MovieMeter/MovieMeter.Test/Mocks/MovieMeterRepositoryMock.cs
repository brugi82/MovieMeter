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
        private List<Program> _repository = new List<Program>();

        public bool GetAllProgramsCalled { get; internal set; }

        public Task<List<Program>> GetAllPrograms()
        {
            GetAllProgramsCalled = true;

            return Task.Run(() => _repository);
        }

        public List<Program> MockRepository
        {
            get
            {
                return _repository;
            }
        }
    }
}
