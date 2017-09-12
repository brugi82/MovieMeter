using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            var container = new Container();

            container.RegisterDependancies();
        }
    }
}
