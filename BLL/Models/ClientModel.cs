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
        public string phoneNumber { get; set; }
        public DateTime? dateConnect { get; set; }

        public decimal? balance { get; set; }

        public bool? isPhysCl { get; set; }

        public string password { get; set; }
        public int? freeMin { get; set; }

        public int? freeSms { get; set; }

        public float? freeGB { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string numberPassport { get; set; }

        public string nameOrganisation { get; set; }
        public string legalAdress { get; set; }
        public string ITN { get; set; }
        public DateTime? startDate { get; set; }
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
            if (isPhysCl == true)
            {
                name = client.name;
                surname = client.surName;
                dateOfBirth = client.dateOfBirth;
                numberPassport = client.numberPassport;
            }
            else
            {
                nameOrganisation = client.nameOrganization;
                legalAdress = client.legalAdress;
                ITN = client.ITN;
                startDate = client.startDate;
            }
            
        }
    }
}
