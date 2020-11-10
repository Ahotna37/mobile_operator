namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Worker")]
    public partial class Worker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(10)]
        public string mailWorker { get; set; }

        [StringLength(10)]
        public string fullName { get; set; }

        [StringLength(10)]
        public string position { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateOfBirth { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateStartWork { get; set; }

        [StringLength(10)]
        public string password { get; set; }
    }
}
