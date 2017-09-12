using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model
{
    public class Update
    {
        public Update()
        {
            //Id = Guid.NewGuid().ToString();
        }

        public Update(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public DateTime UpdatedOn { get; set; }
        //public Source Source { get; set; }
    }
}
