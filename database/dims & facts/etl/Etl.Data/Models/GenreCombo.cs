using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class GenreCombo
    {
        public int Id { get; set; }
        public int GenreGroupId { get; set; }
        public int GenreId { get; set; }

        public virtual GenreDim Genre { get; set; }
        public virtual GenreGroupDim GenreGroup { get; set; }
    }
}
