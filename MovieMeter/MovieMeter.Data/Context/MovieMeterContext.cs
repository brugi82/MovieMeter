using MovieMeter.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Data.Context
{
    public class MovieMeterContext : DbContext
    {
        static MovieMeterContext()
        {
            Database.SetInitializer<MovieMeterContext>(null);
        }

        public MovieMeterContext()
            : base("Name=MovieMeterContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<Program> Programs { get; set; }
    }
}
