using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ClientModel
    {
        public int id { get; set; }
        public int? phoneNumber { get; set; }
        public DateTime? dateConnect { get; set; }

        public decimal? balance { get; set; }

        public bool? isPhysCl { get; set; }

        public string password { get; set; }
        public int? freeMin { get; set; }

        public int? freeSms { get; set; }

        public float? freeGB { get; set; }
        public ClientModel()
        {

        }
        public ClientModel(Client client)
        {

            id = client.id;
            phoneNumber = client.phoneNumber;
            dateConnect = client.dateConnect;
            balance = client.balance;
            isPhysCl = client.isPhysCl;
            password = client.password;
            freeGB = client.freeGB;
            freeMin = client.freeMin;
            freeSms = client.freeSms;
            
        }
    }
}
