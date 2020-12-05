using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ExtraServiceModel
    {
        public string name { get; set; }
        public decimal? subscFee { get; set; }
        public string description { get; set; }
        public bool? CanConnectThisSer { get; set; }

        public int id { get; set; }
        public ExtraServiceModel()
        {

        }
        public ExtraServiceModel(ExtraService service)
        {

            id = service.id;
            name = service.name;
            subscFee = service.subscFee;
            description = service.description;
            CanConnectThisSer = service.CanConnectThisSer;
        }
    }
}
