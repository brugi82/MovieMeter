using MovieMeter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Repository.Contracts
{
    public interface IMovieMeterRepository
    {
        Task<List<Program>> GetAllPrograms();
        Task HarvestMovieData();
    }
}
