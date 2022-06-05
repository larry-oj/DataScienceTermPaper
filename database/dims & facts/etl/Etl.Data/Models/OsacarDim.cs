using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class OsacarDim
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public bool Winner { get; set; }
        public int CeremonyNum { get; set; }
        public int CeremonyYear { get; set; }

        public virtual CategoryDim Category { get; set; }
    }
}
