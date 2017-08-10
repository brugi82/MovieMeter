using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model
{
    public interface IProgramInfo
    {
        string Name { get; set; }
        int Year { get; set; }
        string Source { get; set; }
    }
}
