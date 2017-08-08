using MovieMeter.WebHarvester.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.WebHarvester.Interpreters
{
    public class TMNInterpreter : IInterpreter
    {
        public List<Tuple<string, int>> Interpret(string page)
        {
            var result = new List<Tuple<string, int>>();

            return result;
        }
    }
}
