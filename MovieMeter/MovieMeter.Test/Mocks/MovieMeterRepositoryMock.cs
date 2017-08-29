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

        public Task<List<Update>> GetAllUpdates()
        {
            GetAllUpdatesCalled = true;
            return Task.Run(() => new List<Update>());
        }

        public Task<List<Update>> GetUpdatesForSource(string sourceId)
        {
            GetUpdatesCalled = true;
            GetUpdatesSourceId = sourceId;
            return Task.Run(() => new List<Update>());
        }

        public Task<Update> GetLatestUpdateForSource(string sourceId)
        {
            GetLatestUpdateCalled = true;
            GetLatestUpdateSourceId = sourceId;
            return Task.Run(() => new Update());
        }

        public Task<List<Source>> GetAllSources()
        {
            GetAllSourcesCalled = true;
            return Task.Run(() => new List<Source>());
        }

        public Task<Source> GetSource(string sourceId)
        {
            GetSourceCalled = true;
            GetSourceId = sourceId;
            return Task.Run(() => new Source());
        }

        public List<Program> MockRepository
        {
            get
            {
                return _repository;
            }
        }

        public bool GetAllUpdatesCalled { get; internal set; }
        public bool GetUpdatesCalled { get; internal set; }
        public bool GetLatestUpdateCalled { get; internal set; }
        public string GetUpdatesSourceId { get; internal set; }
        public string GetLatestUpdateSourceId { get; internal set; }
        public bool GetAllSourcesCalled { get; set; }
        public bool GetSourceCalled { get; set; }
        public string GetSourceId { get; set; }
    }
}
