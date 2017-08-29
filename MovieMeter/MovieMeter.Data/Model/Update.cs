using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Data.Model
{
    public class Update
    {
        public int Id { get; set; }
        public DateTime UpdatedOn { get; set; }

        public string SourceId { get; set; }
        public virtual Source Source { get; set; }

    }
}
