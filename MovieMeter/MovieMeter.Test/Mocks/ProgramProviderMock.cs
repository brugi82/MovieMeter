using MovieMeter.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Model;

namespace MovieMeter.Test.Mocks
{
    public class ProgramProviderMock : IProgramProvider
    {


        public ProgramProviderMock()
        {
            HarvestedPrograms = MockFactory.GetPrograms();
            UpdatedHarvestedPrograms = MockFactory.GetUpdatedPrograms();
        }

        public bool GetProgramsCalled { get; internal set; }

        public Task<List<Program>> GetPrograms()
        {
            GetProgramsCalled = true;
            return Task.Run(() => new List<Program>());
        }

        public List<Program> HarvestedPrograms { get; private set; } = new List<Program>();
        public List<Program> UpdatedHarvestedPrograms { get; private set; } = new List<Program>();

    }
}
