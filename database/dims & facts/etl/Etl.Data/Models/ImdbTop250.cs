using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class ImdbTop250
    {
        public int RatingId { get; set; }
        public int Imdbyear { get; set; }
        public string Imdblink { get; set; }
        public string Title { get; set; }
        public int Date { get; set; }
        public int RunTime { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public decimal? Score { get; set; }
        public int Votes { get; set; }
        public decimal? Gross { get; set; }
        public string Director { get; set; }
        public string Cast1 { get; set; }
        public string Cast2 { get; set; }
        public string Cast3 { get; set; }
        public string Cast4 { get; set; }
    }
}
