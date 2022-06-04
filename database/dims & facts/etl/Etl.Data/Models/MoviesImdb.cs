using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class MoviesImdb
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int TimeMin { get; set; }
        public decimal Imdb { get; set; }
        public string Metascore { get; set; }
        public int Votes { get; set; }
        public string UsGrossMillions { get; set; }
    }
}
