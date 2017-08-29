using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Data.Model
{
    public class Source
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int ParserId { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<Update> Updates { get; set; }
    }
}
