using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class LegalPersonModel
    {
        public string name { get; set; }
        public string legalAdress { get; set; }
        public string ITN { get; set; }
        public DateTime? startDate { get; set; }
        public int id { get; set; }
        public LegalPersonModel()
        {

        }
        public LegalPersonModel(LegalPerson legal)
        {

            id = legal.id;
            name = legal.name;
            legalAdress = legal.legalAdress;
            ITN = legal.ITN;
            startDate = legal.startDate;
        }
    }
}
