namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConnectService")]
    public partial class ConnectService
    {
        [Key]
        public int idConnectServ { get; set; }

        public int? idClient { get; set; }

        public int? idExtraService { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateConnectBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateConnectEnd { get; set; }

        public virtual Client Client { get; set; }

        public virtual ExtraService ExtraService { get; set; }
    }
}
