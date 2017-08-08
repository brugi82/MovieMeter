using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.WebHarvester.Contracts
{
    public interface IInterpreter
    {
        List<Tuple<string, int>> Interpret(string page);
    }
}
