using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<Call> Call { get; }
        IRepository<Worker> Worker { get; }
        IRepository<Sms> Sms { get; }
        IRepository<Client> Client { get; }
        IRepository<ConnectService> ConnectService { get; }
        IRepository<ConnectTariff> ConnectTariff { get; }
        IRepository<LegalPerson> LegalPerson { get; }
        IRepository<PhysicalPerson> PhysicalPerson { get; }
        IRepository<TariffPlan> TariffPlan { get; }
        IReportsRepository Reports { get; }
        int Save();
    }
}
