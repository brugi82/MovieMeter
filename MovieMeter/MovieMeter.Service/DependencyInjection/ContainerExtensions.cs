using MovieMeter.Model.Contracts;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMeter.Repository.DependencyInjection;
using MovieMeter.WebHarvester.DependencyInjection;

namespace MovieMeter.Service.DependencyInjection
{
    public static class ContainerExtensions
    {
        public static void RegisterService(this Container container)
        {
            container.RegisterRepositories();
            container.RegisterHarvester();
            container.Register<IMovieMeterService, MovieMeterService>();
        }
    }
}
