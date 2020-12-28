using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CallModel
    {
        DbOperation db = new DbOperation();
        public DateTime? dateCall { get; set; }
        public string dateCallShort { get; set; }

        public int? timeTalk { get; set; }

        public string numberWasCall { get; set; }
        public string incomingCallText { get; set; }
        

        public int? callType { get; set; }
        public String callTypeString { get; set; }
        public bool? incomingCall { get; set; }
        public int? idClient { get; set; }

        public int id { get; set; }
        public Double costCall { get; set; }

        //public virtual Client Client { get; set; }
        public CallModel()
        {

        }
        public CallModel(Call call)
        {
            TariffPlanModel activeTariff = db.GetActiveTariff(Convert.ToInt32(call.idClient));
            ClientModel client = db.GetItemClient(Convert.ToInt32(call.idClient));

            dateCall = call.dateCall;
            dateCallShort = Convert.ToDateTime(dateCall).ToString("d");
            timeTalk = call.timeTalk;
            numberWasCall = call.numberWasCall;
            callType = call.callType;
            switch (callType)
            {
                case 1:
                    callTypeString = "Городской";
                    break;
                case 2:
                    callTypeString = "Междугородний";
                    break;
                case 3:
                    callTypeString = "В другую страну";
                    break;
            }
            costCall = Convert.ToDouble(call.costCall);
            incomingCall = call.incomingCall;
            switch (incomingCall)
            {
                case true:
                    incomingCallText = "Исходящий";
                    break;
                case false:
                    incomingCallText = "Входящий";
                    break;
            }
            /*            if (client.freeMin == 0)
                        {
                            switch (callType)
                            {
                                case 1:
                                    costCall = Convert.ToDouble(-(timeTalk * activeTariff.costOneMinCallCity));
                                    db.UpdateBalanceClient(Convert.ToInt32(call.idClient), Convert.ToInt32( costCall));
                                    break;
                                case 2:
                                    costCall = Convert.ToDouble(-(timeTalk * activeTariff.costOneMinCallOutCity));
                                    db.UpdateBalanceClient(Convert.ToInt32(call.idClient), Convert.ToInt32(costCall));
                                    break;
                                case 3:
                                    costCall = Convert.ToDouble(-(timeTalk * activeTariff.CostOneMinCallInternation));
                                    db.UpdateBalanceClient(Convert.ToInt32(call.idClient), Convert.ToInt32(costCall));
                                    break;
                            }
                        }else
                            if (client.freeMin > 0)
                        {
                            var timeFree = client.freeMin - timeTalk;
                            if (timeFree >= 0)
                            {
                                costCall = 0;
                                db.UpdateFreeMinForClient(Convert.ToInt32(call.idClient), Convert.ToInt32(timeFree));
                            }else
                                if (timeFree < 0)
                            {
                                db.UpdateFreeMinForClient(Convert.ToInt32(call.idClient), Convert.ToInt32(client.freeMin - client.freeMin));
                                switch (callType)
                                {
                                    case 1:
                                        costCall = Convert.ToDouble(timeFree * activeTariff.costOneMinCallCity);
                                        db.UpdateBalanceClient(Convert.ToInt32(call.idClient), Convert.ToInt32(costCall));
                                        break;
                                    case 2:
                                        costCall = Convert.ToDouble(timeFree * activeTariff.costOneMinCallOutCity);
                                        db.UpdateBalanceClient(Convert.ToInt32(call.idClient), Convert.ToInt32(costCall));
                                        break;
                                    case 3:
                                        costCall = Convert.ToDouble(timeFree * activeTariff.CostOneMinCallInternation);
                                        db.UpdateBalanceClient(Convert.ToInt32(call.idClient), Convert.ToInt32(costCall));
                                        break;
                                }
                            }
                        }*/
            idClient = call.idClient;
            id = call.id;
        }

    }
}
