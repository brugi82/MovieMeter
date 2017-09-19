using HtmlAgilityPack;
using MovieMeter.Model;
using MovieMeter.WebHarvester.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.WebHarvester.Parsers
{
    public class TMNParser : IParser
    {
        private const string Source = "TMN";

        public IProgramInfo Parse(string htmlPage)
        {
            var result = new List<Tuple<string, int>>();

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlPage);
            var program = GetBasicInfo(document);
            GetOnDemandDates(document, program);

            return program;
        }

        private static IProgramInfo GetBasicInfo(HtmlDocument document)
        {
            var container = document.DocumentNode.Descendants().Where(node => node.GetAttributeValue("class", string.Empty).Equals("info-container"))
                                        .Single();

            var name = container.Descendants("h1").Single().InnerText;
            var details = container.Descendants().Where(node => node.GetAttributeValue("class", string.Empty).Equals("ratings")).Single().InnerText;
            var detailsCollection = details.Split('•');

            int year = -1;
            for (int index = 0; index < detailsCollection.Count(); index++)
            {
                if (int.TryParse(detailsCollection[index], out year))
                    break;
            }
            return new ProgramInfo(name, year, Source);
        }

        private static void GetOnDemandDates(HtmlDocument document, IProgramInfo program)
        {
            try
            {
                var onDemand = document.DocumentNode.Descendants().Where(node => node.GetAttributeValue("class", string.Empty).Equals("on-demand")).Single();
                var timeNodes = onDemand.Descendants().Where(node => node.Name == "time").ToList();
                foreach (var timeNode in timeNodes)
                    timeNode.Descendants().Where(node => node.Name == "span").First().Remove();

                program.OnDemandStarts = Convert.ToDateTime(timeNodes[0].InnerText);
                program.OnDemandEnds = Convert.ToDateTime(timeNodes[1].InnerText);
            }
            catch
            {

            }
        }
    }
}
