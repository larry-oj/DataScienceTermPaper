using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class ImdbTop1000
    {
        public string PosterLink { get; set; }
        public string SeriesTitle { get; set; }
        public string ReleasedYear { get; set; }
        public string Certificate { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public decimal ImdbRating { get; set; }
        public string Overview { get; set; }
        public int? MetaScore { get; set; }
        public string Director { get; set; }
        public string Star1 { get; set; }
        public string Star2 { get; set; }
        public string Star3 { get; set; }
        public string Star4 { get; set; }
        public int NoOfVotes { get; set; }
        public string Gross { get; set; }
    }
}
