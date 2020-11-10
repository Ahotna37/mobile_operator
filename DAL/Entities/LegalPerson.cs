namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LegalPerson")]
    public partial class LegalPerson
    {
        [StringLength(10)]
        public string name { get; set; }

        [StringLength(10)]
        public string legalAdress { get; set; }

        [StringLength(10)]
        public string ITN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? idClient { get; set; }

        public virtual Client Client { get; set; }
    }
}
