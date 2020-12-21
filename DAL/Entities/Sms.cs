namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sms
    {
        public int id { get; set; }

        public int? idClient { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateSms { get; set; }

        [StringLength(50)]
        public string recipientSms { get; set; }

        [Column(TypeName = "text")]
        public string textSms { get; set; }

        public decimal? costSMS { get; set; }

        public virtual Client Client { get; set; }
    }
}
