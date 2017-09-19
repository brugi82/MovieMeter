using MovieMeter.WebHarvester.Contracts;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.WebHarvester.Harvester
{
    public static class HarvesterFactory
    {
        public static IWebPageLoader GetSeleniumLoader()
        {
            try
            {
                return new SeleniumTMNLoader(new PhantomJSDriver());
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
