namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AddBalance")]
    public partial class AddBalance
    {
        public int id { get; set; }

        public int? idClient { get; set; }

        public int? SumForAdd { get; set; }

        [StringLength(50)]
        public string phoneNumberForAddBalance { get; set; }

        [StringLength(50)]
        public string numberBankCard { get; set; }

        [StringLength(50)]
        public string nameBankCard { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateBankCard { get; set; }

        public int? CVVBankCard { get; set; }

        public virtual Client Client { get; set; }
    }
}
