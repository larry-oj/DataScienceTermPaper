using System;
using System.Collections.Generic;

namespace Etl.Data.Models
{
    public partial class Fact
    {
        public int Id { get; set; }
        public int GenreGroupId { get; set; }
        public int? OscarGroupId { get; set; }
        public int TimeDim { get; set; }
        public int DirectorId { get; set; }
        public int ActorGroupId { get; set; }
        public int FilmId { get; set; }
        public double? Rating { get; set; }
        public int? Score { get; set; }
        public int? Gross { get; set; }
        public int? Runtime { get; set; }
        public int? Votes { get; set; }

        public virtual ActorGroupDim ActorGroup { get; set; }
        public virtual PersonDim Director { get; set; }
        public virtual FilmDim Film { get; set; }
        public virtual GenreGroupDim GenreGroup { get; set; }
        public virtual OscarGroupDim? OscarGroup { get; set; }
        public virtual TimeDim TimeDimNavigation { get; set; }
    }
}
