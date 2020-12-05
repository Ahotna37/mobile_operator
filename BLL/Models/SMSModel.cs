using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SMSModel
    {
        public int id { get; set; }
        public int? idClient { get; set; }

        public DateTime? dateSms { get; set; }

        public string recipientSms { get; set; }
        public string textSms { get; set; }
        public SMSModel()
        {

        }
        public SMSModel(Sms sms)
        {

            id = sms.id;
            idClient = sms.idClient;
            dateSms = sms.dateSms;
            recipientSms = sms.recipientSms;
            textSms = sms.textSms;
        }
    }
}
