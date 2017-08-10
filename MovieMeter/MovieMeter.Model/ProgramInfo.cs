﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Model
{
    public class ProgramInfo : IProgramInfo
    {
        public ProgramInfo()
        {

        }

        public ProgramInfo(string name, int year, string source)
        {
            Name = name;
            Source = source;
            Year = year;
        }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Source { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Year}, {Source}";
        }
    }
}