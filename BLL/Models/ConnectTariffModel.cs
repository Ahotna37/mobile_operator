using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ConnectTariffModel
    {
        public string name { get; set; }
        public decimal? cost { get; set; }
        public DateTime? dateConnectTariffBegin { get; set; }
        public DateTime? dateConnectTariffEnd { get; set; }
        public int? idClient { get; set; }
        public int? connectedMonth { get; set; }
        public ConnectTariffModel()
        {
        }
        public ConnectTariffModel(TariffPlanModel tariffPlan, ConnectTariff connectTariff)
        {
            name = tariffPlan.name;

            dateConnectTariffBegin = connectTariff.dateConnectTariffBegin;
            dateConnectTariffEnd = connectTariff.dateConnectTariffEnd;
            idClient = connectTariff.idClient;
            if(dateConnectTariffEnd == null)
            {
                DateTime dateNow = DateTime.Now;
                connectedMonth = 0;
                while (Convert.ToDateTime(dateConnectTariffBegin).AddMonths(1) < dateNow)
                    connectedMonth++;
            }
            else
            {
                connectedMonth = 0;
                while (Convert.ToDateTime(dateConnectTariffBegin).AddMonths(1) < dateConnectTariffEnd)
                    connectedMonth++;
            }
            cost = tariffPlan.subscriptionFee*connectedMonth + tariffPlan.costChangeTar;
        }
    }
}
