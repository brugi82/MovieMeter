using MovieMeter.API.Controllers;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.API.DependencyInjection
{
    public static class ContainerExtensions
    {
        public static void RegisterWebApis(this Container container)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<ProgramsController>();
            container.Register<UpdatesController>();
            container.Register<ProgramsCountController>();
        }
    }
}
