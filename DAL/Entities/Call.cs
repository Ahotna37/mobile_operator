namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Call")]
    public partial class Call
    {
        [Column(TypeName = "date")]
        public DateTime? dateCall { get; set; }

        public int? timeTalk { get; set; }

        [StringLength(10)]
        public string numberWasCall { get; set; }

        public int? callType { get; set; }

        public int? idClient { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public virtual Client Client { get; set; }
    }
}
