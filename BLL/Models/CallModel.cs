using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CallModel
    {
        public DateTime? dateCall { get; set; }

        public int? timeTalk { get; set; }

        public string numberWasCall { get; set; }

        public int? callType { get; set; }

        public int? idClient { get; set; }

        public int id { get; set; }

        //public virtual Client Client { get; set; }
        public CallModel()
        {

        }
        public CallModel(Call call)
        {

            dateCall = call.dateCall;
            timeTalk = call.timeTalk;
            numberWasCall = call.numberWasCall;
            callType = call.callType;
            idClient = call.idClient;
            id = call.id;
        }
    }
}
