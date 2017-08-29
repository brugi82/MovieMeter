using MovieMeter.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Model;
using MovieMeter.Data.Context;
using AutoMapper;
using System.Data.Entity;
using MovieMeter.WebHarvester.Harvester;
using MovieMeter.WebHarvester.Parsers;

namespace MovieMeter.Repository.Repositories
{
    public class MovieMeterEFRepository : IMovieMeterRepository
    {
        private MovieMeterContext _context;
        private IMapper _mapper;

        public MovieMeterEFRepository(MovieMeterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Program>> GetAllPrograms()
        {
            var query = await _context.Programs.ToListAsync();
            var programs = query.Select(elem => _mapper.Map<Program>(elem)).ToList();

            return programs;
        }

        public async Task<List<Source>> GetAllSources()
        {
            var query = await _context.Sources.ToListAsync();
            var sources = query.Select(elem => _mapper.Map<Source>(elem)).ToList();

            return sources;
        }

        public async Task<List<Update>> GetAllUpdates()
        {
            var query = await _context.Updates.ToListAsync();
            var updates = query.Select(elem => _mapper.Map<Update>(elem)).ToList();

            return updates;
        }

        public async Task<Update> GetLatestUpdateForSource(string sourceId)
        {
            var query = await _context.Updates.Where(elem => elem.SourceId == sourceId).OrderBy(elem => elem.UpdatedOn).FirstOrDefaultAsync();

            var update = _mapper.Map<Update>(query);

            return update;
        }

        public async Task<Source> GetSource(string sourceId)
        {
            var query = await _context.Sources.Where(elem => elem.Id == sourceId).SingleAsync();

            var source = _mapper.Map<Source>(query);

            return source;
        }

        public async Task<List<Update>> GetUpdatesForSource(string sourceId)
        {
            var query = await _context.Updates.Where(elem => elem.SourceId == sourceId).OrderBy(elem => elem.UpdatedOn).ToListAsync();

            var updates = query.Select(elem => _mapper.Map<Update>(elem)).ToList();

            return updates;
        }
    }
}
