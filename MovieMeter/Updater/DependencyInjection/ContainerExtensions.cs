using MovieMeter.Service.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.DependencyInjection
{
    public static class ContainerExtensions
    {
        public static void RegisterDependancies(this Container container)
        {
            //container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            container.RegisterService();
        }
    }
}
