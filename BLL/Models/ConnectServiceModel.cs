using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ConnectServiceModel
    {
        public string name { get; set; }
        public decimal? cost { get; set; }
        public DateTime? dateConnectServiceBegin { get; set; }
        public DateTime? dateConnectServiceEnd { get; set; }
        public int? idClient { get; set; }
        public int? connectedMonth { get; set; }
        public ConnectServiceModel()
        {
        }
        public ConnectServiceModel(ExtraServiceModel serviceModel, ConnectService connectService)
        {
            name = serviceModel.name;
            dateConnectServiceBegin = connectService.dateConnectBegin;
            dateConnectServiceEnd = connectService.dateConnectBegin;
            idClient = connectService.idClient;
            if (dateConnectServiceEnd == null)
            {
                DateTime dateNow = DateTime.Now;
                connectedMonth = 0;
                while (Convert.ToDateTime(dateConnectServiceBegin).AddMonths(1) < dateNow)
                    connectedMonth++;
            }
            else
            {
                connectedMonth = 0;
                while (Convert.ToDateTime(dateConnectServiceBegin).AddMonths(1) < dateConnectServiceEnd)
                    connectedMonth++;
            }
            cost = serviceModel.subscFee * (connectedMonth+1) ;
        }
    }
}
