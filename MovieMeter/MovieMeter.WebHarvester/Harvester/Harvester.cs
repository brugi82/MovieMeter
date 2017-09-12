using MovieMeter.WebHarvester.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Model;

namespace MovieMeter.WebHarvester.Harvester
{
    public class Harvester : IHarvester
    {
        private IParser _parser;

        public Harvester(IParser parser)
        {
            _parser = parser;
        }

        public async Task<List<IProgramInfo>> Harvest()
        {
            var programs = new List<IProgramInfo>();
            using (var loader = HarvesterFactory.GetSeleniumLoader())
            {
                var pages = await loader.GetProgramPagesHtml();

                foreach (var page in pages)
                {
                    programs.Add(_parser.Parse(page));
                }
            }

            return programs;
        }
    }
}
