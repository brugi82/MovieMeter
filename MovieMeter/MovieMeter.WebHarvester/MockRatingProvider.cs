using MovieMeter.WebHarvester.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Model;

namespace MovieMeter.WebHarvester
{
    public class MockRatingProvider : IRatingProvider
    {
        public async Task<List<Program>> GetProgramDetails(List<IProgramInfo> programs)
        {
            var result = new List<Program>();
            var ran = new Random();
            await Task.Run(() =>
            {
                int id = 0;
                foreach (var progr in programs)
                {
                    result.Add(new Program()
                    {
                        Id = id.ToString(),
                        Title = progr.Title,
                        Year = progr.Year,
                        ImdbId = id.ToString(),
                        ImdbRating = ran.Next(10),
                        OnDemandStarts = progr.OnDemandStarts,
                        OnDemandEnds = progr.OnDemandEnds
                    });

                    id++;
                }
            });

            return result;
        }
    }
}
