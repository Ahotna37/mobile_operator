using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TariffPlanModel
    {
        public string name { get; set; }
        public decimal? costOneMinCallCity { get; set; }
        public decimal? costOneMinCallOutCity { get; set; }
        public decimal? CostOneMinCallInternation { get; set; }
        public float? intGB { get; set; }
        public int? SMS { get; set; }
        public int? subscriptionFee { get; set; }
        public bool? isPhysTar { get; set; }
        public decimal? costChangeTar { get; set; }
        public bool? CanConnectThisTar { get; set; }
        public int id { get; set; }

        public int? freeMinuteForMonth { get; set; }
        public TariffPlanModel()
        {


        }
        public TariffPlanModel(TariffPlan tariff)
        {

            id = tariff.id;
            name = tariff.name;
            costOneMinCallCity = tariff.costOneMinCallCity;
            costOneMinCallOutCity = tariff.costOneMinCallOutCity;
            CostOneMinCallInternation = tariff.CostOneMinCallInternation;
            intGB = tariff.intGB;
            SMS = tariff.SMS;
            subscriptionFee = tariff.subcriptionFee;
            isPhysTar = tariff.isPhysTar;
            costChangeTar = tariff.costChangeTar;
            CanConnectThisTar = tariff.CanConnectThisTar;
            freeMinuteForMonth = tariff.freeMinuteForMonth;
        }
    }
}
