namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhysicalPerson")]
    public partial class PhysicalPerson
    {
        [StringLength(10)]
        public string name { get; set; }

        [StringLength(10)]
        public string surname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateOfBirth { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(10)]
        public string numberPassport { get; set; }

        public virtual Client Client { get; set; }
    }
}
