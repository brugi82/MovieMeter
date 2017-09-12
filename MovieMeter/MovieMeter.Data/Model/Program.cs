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
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public double ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        public string Poster { get; set; }
        public ProgramType Type { get; set; }
        public bool Watched { get; set; }
        public double UserRating { get; set; }

        public string SourceId { get; set; }
        public virtual Source Source { get; set; }
        public int UpdateId { get; set; }
        public virtual Update Update { get; set; }

        public virtual ICollection<ProgramUserData> ProgramUserData { get; set; }

    }
}
