using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.WebHarvester.Harvester
{
    public class SeleniumWebSiteHtmlLoader : IDisposable
    {
        private readonly RemoteWebDriver _remoteWebDriver;

        public SeleniumWebSiteHtmlLoader(RemoteWebDriver remoteWebDriver)
        {
            if (remoteWebDriver == null) throw new ArgumentNullException("remoteWebDriver");
            _remoteWebDriver = remoteWebDriver;
            //_remoteWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public string GetRenderedHtml(string webSiteUrl)
        {
            return GetRenderedHtml(new Uri(webSiteUrl, UriKind.Absolute));
        }

        public string GetRenderedHtml(Uri webSiteUri)
        {
            NavigateTo(webSiteUri);

            return _remoteWebDriver.PageSource;
        }

        public void NavigateTo(string webSiteUrl)
        {
            NavigateTo(new Uri(webSiteUrl, UriKind.Absolute));
        }

        public void NavigateTo(Uri webSiteUri)
        {
            if (webSiteUri == null) throw new ArgumentNullException("webSiteUri");
            _remoteWebDriver.Navigate().GoToUrl(webSiteUri);
        }

        protected RemoteWebDriver WebDriver
        {
            get
            {
                return _remoteWebDriver;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_remoteWebDriver != null)
                {
                    _remoteWebDriver.Quit();
                }
            }
        }
    }
}
