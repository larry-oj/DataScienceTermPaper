using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class TheOscarAward
    {
        public int YearFilm { get; set; }
        public int YearCeremony { get; set; }
        public int Ceremony { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Film { get; set; }
        public string Winner { get; set; }
    }
}
