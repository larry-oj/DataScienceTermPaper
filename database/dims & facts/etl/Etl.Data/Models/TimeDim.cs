using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class TimeDim
    {
        public TimeDim()
        {
            Facts = new HashSet<Fact>();
        }

        public int Id { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Fact> Facts { get; set; }
    }
}
