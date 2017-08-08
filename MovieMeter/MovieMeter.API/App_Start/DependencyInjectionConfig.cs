using MovieMeter.API.DependencyInjection;
using MovieMeter.Repository.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieMeter.API.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();

            container.RegisterWebApis();
            container.RegisterRepositories();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
