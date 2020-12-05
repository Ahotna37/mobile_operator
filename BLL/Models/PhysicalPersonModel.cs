using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PhysicalPersonModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string numberPassport { get; set; }
        public int id { get; set; }
        public PhysicalPersonModel()
        {

        }
        public PhysicalPersonModel(PhysicalPerson physical)
        {

            id = physical.id;
            name = physical.name;
            surname = physical.surname;
            dateOfBirth = physical.dateOfBirth;
            numberPassport = physical.numberPassport;
        }
    }
}
