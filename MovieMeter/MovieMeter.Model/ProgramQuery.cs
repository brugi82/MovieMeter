using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model
{
    public class ProgramQuery
    {
        public double? MinRating { get; set; }
        public double? MaxRating { get; set; }
        public string Genre { get; set; }
        public int? Year { get; set; }
        public uint? MinVotes { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public bool? Watched { get; set; }
        public bool? OnlyActive { get; set; }
    }
}
