using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class Reports
    {
        DbOperation dbOperation = new DbOperation();
        public class ListCalls
        {
            public string dateCallShort { get; set; }
            public int? timeTalk { get; set; }
            public string numberWasCall { get; set; }
            public String callTypeString { get; set; }
            public decimal? cost { get; set; }
        }
        public static List<ListCalls> ReportListCalls(int idClient)
        {
            Context context = new Context();
            var result = context.Call
                .Join(context.Client, call => call.idClient, client => client.id, (call, client) => new { call = call, client = client })
                .Join(context.ConnectTariff, client => client.client.id, connect => connect.idClient, (client, connect) => new { client = client.client, connect = connect })
                .Join(context.TariffPlan, connect => connect.connect.idTariffPlan, tariffPlan => tariffPlan.id, (connect, tariffPlan) => new { connect = connect.connect, tariffPlan = tariffPlan })
                .Where(i => i.connect.idClient == idClient).ToList().Select(i => new ListCalls() {
                    cost = i.tariffPlan.costOneMinCallCity
                })
                .ToList();

            return result;
        }
    }
}
