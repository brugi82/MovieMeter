using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Data.Model
{
    public class Program
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }
        public float ImdbRating { get; set; }
        public int ImdbVotes { get; set; }
        public ProgramType Type { get; set; }
        public int UpdateId { get; set; }

        public string SourceId { get; set; }
        public virtual Source Source { get; set; }

    }
}
