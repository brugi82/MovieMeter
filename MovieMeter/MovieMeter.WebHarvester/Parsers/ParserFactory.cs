using MovieMeter.WebHarvester.Contracts;
using MovieMeter.WebHarvester.Harvester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.WebHarvester.Parsers
{
    public static class ParserFactory
    {
        public static IParser GetParser(IWebPageLoader loader)
        {
            if (loader is SeleniumTMNLoader)
                return new TMNParser();

            return null;
        }
    }
}
