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
        public Task<List<Program>> GetPrograms()
        {
            throw new NotImplementedException();
        }
    }
}
