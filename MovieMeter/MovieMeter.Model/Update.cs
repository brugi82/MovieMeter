using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model
{
    public class Update
    {
        public int Id { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Source Source { get; set; }
    }
}
