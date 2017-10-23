using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieMeter.Model;
using MovieMeter.Model.Contracts;
using MovieMeter.Repository.Contracts;
using MovieMeter.Service;
using MovieMeter.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Test
{
    [TestClass]
    public class MovieMeterServiceTests
    {
        private MovieMeterRepositoryMock _repository;
        private ProgramProviderMock _programProvider;

        [TestInitialize]
        public void InitTests()
        {
            _repository = new MovieMeterRepositoryMock();
            _programProvider = new ProgramProviderMock();
        }

        [TestMethod]
        public void MovieMeterService_GivenRepositoryInCtor_ShouldBeStoredAsProperty()
        {
            var service = new MovieMeterService(_repository, _programProvider);

            Assert.AreSame(_repository, service.Repository);
            Assert.IsNotNull(service.Repository);
        }

        [TestMethod]
        public void MovieMeterService_GivenProviderInCtor_ShouldBeStoredAsProperty()
        {
            var service = new MovieMeterService(_repository, _programProvider);

            Assert.AreSame(_programProvider, service.ProgramProvider);
            Assert.IsNotNull(service.ProgramProvider);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MovieMeterService_GivenNullRepositoryInCtor_ShouldThrowArgumentNullException()
        {
            var service = new MovieMeterService(null, _programProvider);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MovieMeterService_GivenNullProgramProviderInCtor_ShouldThrowArgumentNullException()
        {
            var service = new MovieMeterService(_repository, null);
        }

        [TestMethod]
        public async Task MovieMeterService_WhenGetAllPrograms_ShouldCallRepository()
        {
            var query = new ProgramQuery();
            var service = new MovieMeterService(_repository, _programProvider);

            var programs = await service.GetAllPrograms(query, 25);

            Assert.IsTrue(_repository.GetAllProgramsCalled);
        }

        [TestMethod]
        public async Task MovieMeterService_WhenGetAllUpdates_ShouldGetAllUpdatesFromRepository()
        {
            var service = new MovieMeterService(_repository, _programProvider);

            var updates = await service.GetAllUpdates();

            Assert.IsTrue(_repository.GetAllUpdatesCalled);
        }

        [TestMethod]
        public async Task MovieMeterService_WhenGetUpdates_ShouldRequestUpdatesFromRepositoryForSameSourceId()
        {
            var service = new MovieMeterService(_repository, _programProvider);
            var sourceId = Guid.NewGuid().ToString();

            var updates = await service.GetUpdatesForSource(sourceId);

            Assert.IsTrue(_repository.GetUpdatesCalled);
            Assert.AreEqual(sourceId, _repository.GetUpdatesSourceId);
        }

        [TestMethod]
        public async Task MovieMeterService_WhenGetLatestUpdate_ShouldRequestLatestUpdateFromRepositoryForSameSourceId()
        {
            var service = new MovieMeterService(_repository, _programProvider);
            var sourceId = Guid.NewGuid().ToString();

            var latestUpdate = await service.GetLatestUpdateForSource(sourceId);

            Assert.IsTrue(_repository.GetLatestUpdateCalled);
            Assert.AreEqual(sourceId, _repository.GetLatestUpdateSourceId);
        }

        [TestMethod]
        public async Task MovieMeterService_WhenGetAllSources_ShouldRequestAllSourcesFromRepository()
        {
            var service = new MovieMeterService(_repository, _programProvider);

            var sources = await service.GetAllSources();

            Assert.IsTrue(_repository.GetAllSourcesCalled);
        }

        [TestMethod]
        public async Task MovieMeterService_WhenGetSource_ShouldRequestSourceFromRepositoryWithSameId()
        {
            var service = new MovieMeterService(_repository, _programProvider);
            var sourceId = Guid.NewGuid().ToString();

            var source = await service.GetSource(sourceId);

            Assert.IsTrue(_repository.GetSourceCalled);
            Assert.AreEqual(sourceId, _repository.GetSourceId);
        }



        private void CompareCollections<T>(List<T> source, List<T> target)
        {
            Assert.AreEqual(source.Count, target.Count);

            for (int index = 0; index < source.Count; index++)
            {
                Assert.AreEqual(source[index], target[index]);
            }
        }
    }
}
