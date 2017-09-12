using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Repository.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MovieMeter.Data.Model.Program, MovieMeter.Model.Program>();
                cfg.CreateMap<MovieMeter.Model.Program, MovieMeter.Data.Model.Program>();
                cfg.CreateMap<MovieMeter.Data.Model.Source, MovieMeter.Model.Source>();
                cfg.CreateMap<MovieMeter.Model.Source, MovieMeter.Data.Model.Source>();
                cfg.CreateMap<MovieMeter.Data.Model.Update, MovieMeter.Model.Update>();
                cfg.CreateMap<MovieMeter.Model.Update, MovieMeter.Data.Model.Update>();
            });
        }
    }
}
