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
            container.Register<IMovieMeterRepository, MovieMeterEFRepository>(Lifestyle.Scoped);
        }

        public static void RegisterAutoMapper(this Container container)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MovieMeter.Data.Model.Program, MovieMeter.Model.Program>();
            });

            var mapper = config.CreateMapper();

            container.RegisterSingleton<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance), Lifestyle.Scoped);
        }
    }
}
