using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model
{
    public class Source
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int ParserId { get; set; }
        //public List<Update> Updates { get; set; } = new List<Update>();
        //public List<Program> Programs { get; set; } = new List<Program>();
    }
}
