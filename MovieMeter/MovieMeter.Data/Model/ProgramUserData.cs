using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Data.Model
{
    public class ProgramUserData
    {
        public string UserId { get; set; }
        public string ProgramId { get; set; }

        public bool Watched { get; set; }
        public double UserRating { get; set; }
    }
}
