using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using HtmlAgilityPack;
using MovieMeter.WebHarvester.Contracts;
using OpenQA.Selenium.Support.UI;

namespace MovieMeter.WebHarvester.Harvester
{
    public class SeleniumTMNLoader : SeleniumWebSiteHtmlLoader, IWebPageLoader
    {
        private const string BaseAddress = "http://www.themovienetwork.ca";
        private const string ProgramListAddress = "http://www.themovienetwork.ca/movies#a-z";
        private const string CssSelectorList = ".a-z-list";

        public SeleniumTMNLoader(RemoteWebDriver remoteWebDriver) : base(remoteWebDriver)
        {
        }

        public List<string> GetProgramPagesHtml()
        {
            var result = new List<string>();
            var pageLinks = new List<string>();

            NavigateTo(ProgramListAddress);

            var list = WebDriver.FindElementsByCssSelector(CssSelectorList);
            var children = list.First().FindElements(By.XPath(".//*"));
            foreach (var child in children)
            {
                //if (child.GetAttribute("innerHTML") == "Z")
                if (children.First() != child)
                {
                    var firstElementName = WebDriver.FindElement(By.ClassName("movies-alpha-list")).FindElements(By.TagName("li")).First().FindElements(By.ClassName("title")).Single().FindElements(By.TagName("a")).Single().Text;
                    var count = WebDriver.FindElement(By.ClassName("movies-alpha-list")).FindElements(By.TagName("li")).Count();
                    child.Click();

                WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));

                    //WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
                    wait.Until<bool>(d => d.FindElement(By.ClassName("movies-alpha-list")).FindElements(By.TagName("li")).First().FindElements(By.ClassName("title")).Single().FindElements(By.TagName("a")).Single().Text != firstElementName);
                    //wait.Until<bool>(d => d.FindElement(By.ClassName("movies-alpha-list")).FindElements(By.TagName("li")).Count() != count);
                }
                pageLinks.AddRange(GetLinks(WebDriver.PageSource));
            }

            foreach (var detailsUrl in pageLinks)
                result.Add(GetRenderedHtml(detailsUrl));

            return result;
        }


        private List<string> GetLinks(string azPage)
        {
            var result = new List<string>();
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(azPage);

            var movieList = document.DocumentNode.Descendants().Where(node => node.GetAttributeValue("class", string.Empty).Equals("movies-alpha-list")).Single();
            foreach (var movie in movieList.Descendants("li"))
            {
                var detailsLink = movie.Descendants("a").First().GetAttributeValue("href", string.Empty);
                result.Add(BaseAddress + detailsLink);
            }

            return result;
        }
    }
}
