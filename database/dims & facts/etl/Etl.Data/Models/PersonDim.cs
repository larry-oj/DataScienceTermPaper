using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class PersonDim
    {
        public PersonDim()
        {
            Facts = new HashSet<Fact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Fact> Facts { get; set; }
    }
}
