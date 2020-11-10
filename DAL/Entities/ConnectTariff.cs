namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConnectTariff")]
    public partial class ConnectTariff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idConnectTariff { get; set; }

        public int? idClient { get; set; }

        public int idTariffPlan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateConnectTariff { get; set; }

        public virtual Client Client { get; set; }

        public virtual TariffPlan TariffPlan { get; set; }
    }
}
