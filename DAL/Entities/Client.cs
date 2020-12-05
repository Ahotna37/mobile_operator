namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Call = new HashSet<Call>();
            ConnectService = new HashSet<ConnectService>();
            ConnectTariff = new HashSet<ConnectTariff>();
            Sms = new HashSet<Sms>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? phoneNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateConnect { get; set; }

        public decimal? balance { get; set; }

        public bool? isPhysCl { get; set; }

        [StringLength(10)]
        public string password { get; set; }

        public int? freeMin { get; set; }

        public int? freeSms { get; set; }

        public float? freeGB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Call> Call { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConnectService> ConnectService { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConnectTariff> ConnectTariff { get; set; }

        public virtual LegalPerson LegalPerson { get; set; }

        public virtual PhysicalPerson PhysicalPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sms> Sms { get; set; }
    }
}
