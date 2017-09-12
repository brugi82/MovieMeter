using MovieMeter.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Model;
using MovieMeter.WebHarvester.Contracts;

namespace MovieMeter.WebHarvester
{
    public class ProgramProvider : IProgramProvider
    {
        private IRatingProvider _ratingProvider;
        private IHarvester _harvester;

        public ProgramProvider(IRatingProvider ratingProvider, IHarvester harvester)
        {
            _ratingProvider = ratingProvider;
            _harvester = harvester;
        }
        public async Task<List<Program>> GetPrograms(int parserId)
        {
            var programInfos = await _harvester.Harvest();
            var programs = await _ratingProvider.GetProgramDetails(programInfos);

            return programs;
        }
    }
}
