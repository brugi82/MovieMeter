using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model.Contracts
{
    public interface IProgramProvider
    {
        Task<List<Program>> GetPrograms(int parserId);
    }
}
