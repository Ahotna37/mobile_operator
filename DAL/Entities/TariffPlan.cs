namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TariffPlan")]
    public partial class TariffPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TariffPlan()
        {
            ConnectTariff = new HashSet<ConnectTariff>();
        }

        [StringLength(50)]
        public string name { get; set; }

        public decimal? costOneMinCallCity { get; set; }

        public decimal? costOneMinCallOutCity { get; set; }

        public decimal? CostOneMinCallInternation { get; set; }

        public float? intGB { get; set; }

        public int? SMS { get; set; }

        public bool? isPhysTar { get; set; }

        public decimal? costChangeTar { get; set; }

        public bool? CanConnectThisTar { get; set; }

        public int? subcriptionFee { get; set; }

        public int? freeMinuteForMonth { get; set; }

        public int id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConnectTariff> ConnectTariff { get; set; }
    }
}
