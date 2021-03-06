using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class GenreGroupDim
    {
        public GenreGroupDim()
        {
            Facts = new HashSet<Fact>();
        }

        public int Id { get; set; }

        public virtual ICollection<Fact> Facts { get; set; }
    }
}
