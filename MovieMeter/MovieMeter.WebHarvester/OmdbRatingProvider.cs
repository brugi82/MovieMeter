using MovieMeter.WebHarvester.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Model;
using System.Net.Http;
using Newtonsoft.Json;


namespace MovieMeter.WebHarvester
{
    public class OmdbRatingProvider : IRatingProvider
    {
        private const string omdbBaseAddress = "http://www.omdbapi.com/";
        private const string omdbKey = "plzBanMe";
        private static HttpClient _httpClient = new HttpClient();

        public OmdbRatingProvider()
        {
            _httpClient.BaseAddress = new Uri("http://www.omdbapi.com/");

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Program>> GetProgramDetails(List<IProgramInfo> programs)
        {
            var result = new List<Program>();
            for (int index = 0; index < programs.Count; index++)
            {
                result.Add(await GetProgramDetails(programs[index]));
            }

            return result;
        }

        public async Task<Program> GetProgramDetails(IProgramInfo program)
        {
            var searchString = GetSearchParamsString(program);

            try
            {
                var response = await _httpClient.GetAsync(searchString);

                var deserializedProgram = await response.Content.ReadAsAsync<Program>();
                deserializedProgram.OnDemandStarts = program.OnDemandStarts;
                deserializedProgram.OnDemandEnds = program.OnDemandEnds;
                return deserializedProgram;
            }
            catch (Exception)
            {
                return new Program()
                {
                    Title = program.Title,
                    Year = program.Year
                };
            }
        }

        private string GetSearchParamsString(IProgramInfo program)
        {
            string result = $"?apikey={omdbKey}&t=";

            var titleWords = program.Title.Split(' ');
            for (int index = 0; index < titleWords.Length; index++)
            {
                result += titleWords[index];
                if (index + 1 < titleWords.Length)
                    result += "+";
            }

            if (program.Year > -1)
                result = $"{result}&&y={program.Year}";

            return result;
        }
    }
}
