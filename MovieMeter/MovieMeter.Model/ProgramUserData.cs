using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model
{
    public class ProgramUserData
    {
        public string ProgramId { get; set; }
        public string UserId { get; set; }

        public double UserRating { get; set; }
        public bool Watched { get; set; }
    }
}
