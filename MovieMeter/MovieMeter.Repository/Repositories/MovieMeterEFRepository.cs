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

        public Task<Program> AddOrUpdateProgram(Program program)
        {
            throw new NotImplementedException();
        }

        public async Task AddOrUpdateProgramUserData(ProgramUserData programUserData)
        {
            var existing = await _context.ProgramUserData.FirstOrDefaultAsync(elem => elem.ProgramId == programUserData.ProgramId && elem.UserId == programUserData.UserId);
            if(existing == null)
            {
                var newDbEntity = _mapper.Map<MovieMeter.Data.Model.ProgramUserData>(programUserData);
                _context.ProgramUserData.Add(newDbEntity);
            }
            else
            {
                existing.UserRating = programUserData.UserRating;
                existing.Watched = programUserData.Watched;
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddUpdate(Update update, List<Program> programs, string sourceId)
        {
            var updateDbEntity = _mapper.Map<MovieMeter.Data.Model.Update>(update);
            var sourceDbEntity = await _context.Sources.FirstAsync(elem => elem.Id == sourceId);

            sourceDbEntity.Updates.Add(updateDbEntity);
            _context.Updates.Add(updateDbEntity);

            for (int index = 0; index < programs.Count; index++)
            {
                var program = programs[index];
                var programDbEntity = await _context.Programs.FirstOrDefaultAsync(elem => elem.ImdbId == program.ImdbId);
                if (programDbEntity == null)
                {
                    programDbEntity = _mapper.Map<MovieMeter.Data.Model.Program>(program);
                    sourceDbEntity.Programs.Add(programDbEntity);
                    //_context.Programs.Add(programDbEntity);
                }
                else
                {
                    programDbEntity.ImdbRating = program.ImdbRating;
                    programDbEntity.ImdbVotes = program.ImdbVotes;
                }

                //programDbEntity.Source = sourceDbEntity;
                programDbEntity.Update = updateDbEntity;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Data.Entity.Validation.DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public async Task<List<Program>> GetAllPrograms()
        {
            var query = await _context.Programs.ToListAsync();
            var programs = query.Select(elem => _mapper.Map<Program>(elem)).ToList();

            return programs;
        }

        public Task<List<Program>> GetAllPrograms(ProgramQuery query)
        {
            throw new NotImplementedException();
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

        public async Task<Program> GetProgram(string programId)
        {
            var programData = await _context.Programs.FirstAsync(elem => elem.Id == programId);
            var program = _mapper.Map<Program>(programData);

            return program;
        }

        public async Task<Source> GetSource(string sourceId)
        {
            Source source = null;
            try
            {
                source = await _context.Sources.Where(elem => elem.Id == sourceId).ProjectToSingleAsync<Source>(_mapper.ConfigurationProvider);

                //source = _mapper.Map<Source>(query);
            }
            catch(Exception ex)
            {

            }

            return source;
        }

        public async Task<List<Update>> GetUpdatesForSource(string sourceId)
        {
            var query = await _context.Updates.Where(elem => elem.SourceId == sourceId).OrderBy(elem => elem.UpdatedOn).ToListAsync();

            var updates = query.Select(elem => _mapper.Map<Update>(elem)).ToList();

            return updates;
        }

        public async Task UpdateProgram(Program program)
        {
            if (program == null || string.IsNullOrEmpty(program.Id))
                throw new ArgumentException("Unable to update", nameof(program));

            var programData = await _context.Programs.FirstAsync(elem => elem.Id == program.Id);

            programData.ImdbRating = program.ImdbRating;
            programData.ImdbVotes = program.ImdbVotes;
            programData.Watched = program.Watched;
            programData.UserRating = program.UserRating;
        }
    }
}
