using MovieMeter.Data.Context;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Data.DependencyInjection
{
    public static class ContainerExtensions
    {
        public static void RegisterDatabase(this Container container)
        {
            container.Register<MovieMeterContext>(Lifestyle.Singleton);
        }
    }
}
