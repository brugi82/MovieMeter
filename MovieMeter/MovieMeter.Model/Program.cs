using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model
{
    public class Program
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }
        public double ImdbRating { get; set; }
        public int ImdbVotes { get; set; }
        public string Source { get; set; }
        public ProgramType Type { get; set; }
    }
}
