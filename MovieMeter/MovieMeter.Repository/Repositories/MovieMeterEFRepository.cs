﻿using MovieMeter.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Model;
using MovieMeter.Data.Context;
using AutoMapper;
using System.Data.Entity;

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
    }
}