using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class CategoryDim
    {
        public CategoryDim()
        {
            OsacarDims = new HashSet<OsacarDim>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OsacarDim> OsacarDims { get; set; }
    }
}
