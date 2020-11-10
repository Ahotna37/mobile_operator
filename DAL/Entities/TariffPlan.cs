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

        [StringLength(10)]
        public string name { get; set; }

        public decimal? subscrFee { get; set; }

        public decimal? costOneMinCall { get; set; }

        public int? intGB { get; set; }

        public int? SMS { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConnectTariff> ConnectTariff { get; set; }
    }
}
