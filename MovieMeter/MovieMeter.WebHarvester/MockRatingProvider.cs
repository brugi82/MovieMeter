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
                foreach (var progr in programs)
                {
                    result.Add(new Program()
                    {
                        Title = progr.Title,
                        Year = progr.Year,
                        ImdbId = Guid.NewGuid().ToString(),
                        ImdbRating = ran.Next(10)
                    });
                }
            });

            return result;
        }
    }
}
