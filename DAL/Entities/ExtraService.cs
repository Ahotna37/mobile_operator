namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExtraService")]
    public partial class ExtraService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExtraService()
        {
            ConnectService = new HashSet<ConnectService>();
        }

        [StringLength(10)]
        public string name { get; set; }

        public decimal? subscFee { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public bool? CanConnectThisSer { get; set; }

        public int id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConnectService> ConnectService { get; set; }
    }
}
