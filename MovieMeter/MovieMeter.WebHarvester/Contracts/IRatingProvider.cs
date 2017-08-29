using MovieMeter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.WebHarvester.Contracts
{
    public interface IRatingProvider
    {
        Task<List<Program>> GetProgramDetails(List<IProgramInfo> programs);
    }
}
