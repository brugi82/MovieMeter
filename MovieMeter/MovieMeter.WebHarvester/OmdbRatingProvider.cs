using MovieMeter.WebHarvester.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Model;
using System.Net.Http;

namespace MovieMeter.WebHarvester
{
    public class OmdbRatingProvider : IRatingProvider
    {
        private const string omdbBaseAddress = "http://www.omdbapi.com/";
        private const string omdbKey = ""
        private static HttpClient _httpClient = new HttpClient();

        public OmdbRatingProvider()
        {
            _httpClient.BaseAddress = new Uri("http://www.omdbapi.com/");
        }

        public async Task<List<Program>> GetProgramDetails(List<IProgramInfo> programs)
        {
            
        }
    }
}
