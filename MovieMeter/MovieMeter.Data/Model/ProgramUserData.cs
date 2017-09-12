using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Data.Model
{
    public class ProgramUserData
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ProgramId { get; set; }

        public bool Watched { get; set; }
        public double UserRating { get; set; }

        public Program Program { get; set; }
        public User User { get; set; }
    }
}
