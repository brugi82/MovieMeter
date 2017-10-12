using AutoMapper;
using MovieMeter.Data.DependencyInjection;
using MovieMeter.Repository.Contracts;
using MovieMeter.Repository.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Repository.DependencyInjection
{
    public static class ContainerExtensions
    {
        public static void RegisterRepositories(this Container container)
        {
            container.RegisterDatabase();
            container.RegisterAutoMapper();
            container.Register<IMovieMeterRepository, MovieMeterEFRepository>();
        }

        public static void RegisterAutoMapper(this Container container)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MovieMeter.Data.Model.Program, MovieMeter.Model.Program>();
                cfg.CreateMap<MovieMeter.Model.Program, MovieMeter.Data.Model.Program>();
                cfg.CreateMap<MovieMeter.Data.Model.Source, MovieMeter.Model.Source>();
                cfg.CreateMap<MovieMeter.Model.Source, MovieMeter.Data.Model.Source>();
                cfg.CreateMap<MovieMeter.Data.Model.Update, MovieMeter.Model.Update>();
                cfg.CreateMap<MovieMeter.Model.Update, MovieMeter.Data.Model.Update>();
                //cfg.CreateMap<MovieMeter.Data.Model.ProgramType, MovieMeter.Model.ProgramType>();
                //cfg.CreateMap<MovieMeter.Model.ProgramType, MovieMeter.Data.Model.ProgramType>();
                cfg.CreateMap<MovieMeter.Data.Model.ProgramUserData, MovieMeter.Model.ProgramUserData>();
                cfg.CreateMap<MovieMeter.Model.ProgramUserData, MovieMeter.Data.Model.ProgramUserData>();
            });

            //var mapper = config.CreateMapper();

            container.RegisterSingleton<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));
        }
    }
}
