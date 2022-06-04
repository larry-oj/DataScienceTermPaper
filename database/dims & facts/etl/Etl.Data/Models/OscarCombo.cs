using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class OscarCombo
    {
        public int OsacrGroupId { get; set; }
        public int OscarDimId { get; set; }

        public virtual OscarGroupDim OsacrGroup { get; set; }
        public virtual OsacarDim OscarDim { get; set; }
    }
}
