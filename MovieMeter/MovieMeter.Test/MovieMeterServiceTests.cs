using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var service = new MovieMeterService(_repository, _programProvider);

            var programs = await service.GetAllPrograms();

            Assert.IsTrue(_repository.GetAllProgramsCalled);
        }

        [TestMethod]
        public async Task MovieMeterService_WhenHarvestMovieData_ShouldCallProgramProvider()
        {
            var service = new MovieMeterService(_repository, _programProvider);

            await service.HarvestMovieData();

            Assert.IsTrue(_programProvider.GetProgramsCalled);
        }
    }
}
