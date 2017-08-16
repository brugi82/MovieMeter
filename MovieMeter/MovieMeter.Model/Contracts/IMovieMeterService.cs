using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model.Contracts
{
    public interface IMovieMeterService
    {
        Task<List<Program>> GetAllPrograms();
        Task HarvestMovieData();
    }
}
