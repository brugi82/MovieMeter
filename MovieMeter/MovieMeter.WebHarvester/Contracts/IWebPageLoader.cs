using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.WebHarvester.Contracts
{
    public interface IWebPageLoader : IDisposable
    {
        List<string> GetProgramPagesHtml();
    }
}
