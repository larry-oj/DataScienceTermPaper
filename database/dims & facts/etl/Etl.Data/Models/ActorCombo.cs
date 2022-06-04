using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class ActorCombo
    {
        public int Id { get; set; }
        public int ActorGroupId { get; set; }
        public int PersonId { get; set; }

        public virtual ActorGroupDim ActorGroup { get; set; }
        public virtual PersonDim Person { get; set; }
    }
}
