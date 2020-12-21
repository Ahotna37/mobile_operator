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
            AddBalance = new HashSet<AddBalance>();
            Call = new HashSet<Call>();
            ConnectService = new HashSet<ConnectService>();
            ConnectTariff = new HashSet<ConnectTariff>();
            Sms = new HashSet<Sms>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string phoneNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateConnect { get; set; }

        public decimal? balance { get; set; }

        public bool? isPhysCl { get; set; }

        [StringLength(10)]
        public string password { get; set; }

        public int? freeMin { get; set; }

        public int? freeSms { get; set; }

        public float? freeGB { get; set; }

        [StringLength(10)]
        public string name { get; set; }

        [StringLength(10)]
        public string surName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateOfBirth { get; set; }

        [StringLength(10)]
        public string numberPassport { get; set; }

        [StringLength(50)]
        public string nameOrganization { get; set; }

        [StringLength(50)]
        public string legalAdress { get; set; }

        [StringLength(10)]
        public string ITN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddBalance> AddBalance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Call> Call { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConnectService> ConnectService { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConnectTariff> ConnectTariff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sms> Sms { get; set; }
    }
}
