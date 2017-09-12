using MovieMeter.WebHarvester.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Model;

namespace MovieMeter.WebHarvester.Harvester
{
    public class MockHarvester : IHarvester
    {
        public async Task<List<IProgramInfo>> Harvest()
        {
            var programs = new List<IProgramInfo>();
            await Task.Run(() =>
            {
                programs.Add(new ProgramInfo("First program", 1990, "Test source"));
                programs.Add(new ProgramInfo("Second program", 1950, "Test source"));
                programs.Add(new ProgramInfo("Third program", 1980, "Test source"));
            });

            return programs;
        }
    }
}
