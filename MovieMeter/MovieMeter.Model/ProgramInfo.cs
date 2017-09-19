using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model
{
    public class ProgramInfo : IProgramInfo
    {
        public ProgramInfo()
        {

        }

        public ProgramInfo(string name, int year, string source)
        {
            Title = name;
            Source = source;
            Year = year;
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Source { get; set; }
        public DateTime? OnDemandStarts { get; set; }
        public DateTime? OnDemandEnds { get; set; }

        public override string ToString()
        {
            return $"{Title}, {Year}, {Source}";
        }
    }
}
