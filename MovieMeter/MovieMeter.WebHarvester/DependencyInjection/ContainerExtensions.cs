using MovieMeter.Model.Contracts;
using MovieMeter.WebHarvester.Contracts;
using MovieMeter.WebHarvester.Harvester;
using MovieMeter.WebHarvester.Parsers;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.WebHarvester.DependencyInjection
{
    public static class ContainerExtensions
    {
        public static void RegisterHarvester(this Container container)
        {
            container.Register<IParser, TMNParser>();
            container.Register<IHarvester, Harvester.Harvester>();
            container.Register<IRatingProvider, OmdbRatingProvider>();
            container.Register<IProgramProvider, ProgramProvider>();
        }
    }
}
