using BLL.Models;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DbOperation
    {
        private Context db;
        public DbOperation()
        {
            db = new Context();
        }

        //ВОЗВРАЩЕНИЕ ПОЛНЫХ СПИСКОВ
        public List<ClientModel> GetAllClients()
        {
            return db.Client.ToList().Select(i => new ClientModel(i)).ToList();
        }
        public List<PhysicalPersonModel> GetAllPhysicalPersons()
        {
            return db.PhysicalPerson.ToList().Select(i => new PhysicalPersonModel(i)).ToList();
        }
        public List<LegalPersonModel> GetAllLegalPersons()
        {
            return db.LegalPerson.ToList().Select(i => new LegalPersonModel(i)).ToList();
        }
        public List<ExtraServiceModel> GetAllExtraServices()
        {
            return db.ExtraService.ToList().Select(i => new ExtraServiceModel(i)).ToList();
        }
        public List<TariffPlanModel> GetAllTariffPlan()
        {
            return db.TariffPlan.ToList().Select(i => new TariffPlanModel(i)).ToList();
        }
        public List<SMSModel> GetAllSMS()
        {
            return db.Sms.ToList().Select(i => new SMSModel(i)).ToList();
        }
        public List<CallModel> GetAllCall()
        {
            return db.Call.ToList().Select(i => new CallModel(i)).ToList();
        }
        //ВОЗВРАЩЕНИЕ КОНКРЕТНЫХ ЭЛЕМЕНТОВ ПО ID
        public ClientModel GetItemClient(int id)
        {
            Client c = db.Client.ToList().Where(i => i.id == id).FirstOrDefault();
            return new ClientModel() { id = c.id, balance = c.balance, dateConnect = c.dateConnect, isPhysCl = c.isPhysCl, password = c.password , phoneNumber = c.phoneNumber  };
        }
        public PhysicalPersonModel GetItemPhysicalPerson(int id)
        {
            PhysicalPerson c = db.PhysicalPerson.ToList().Where(i => i.id == id).FirstOrDefault();
            return new PhysicalPersonModel() { id = c.id, dateOfBirth =c.dateOfBirth, name=c.name, numberPassport =c.numberPassport, surname =c.surname };
        }
        public LegalPersonModel GetItemLegalPerson(int id)
        {
            LegalPerson c = db.LegalPerson.ToList().Where(i => i.id == id).FirstOrDefault();
            return new LegalPersonModel() { name =c.name, id = c.id, ITN = c.ITN, legalAdress =c.legalAdress, startDate =c.startDate };
        }
        public ExtraServiceModel GetItemExtraService(int id)
        {
            ExtraService c = db.ExtraService.ToList().Where(i => i.id == id).FirstOrDefault();
            return new ExtraServiceModel() { CanConnectThisSer =c.CanConnectThisSer, id =c.id, name =c.name, description =c.description, subscFee =c.subscFee };
        }
        public TariffPlanModel GetItemTariffPlan(int id)
        {
            TariffPlan c = db.TariffPlan.ToList().Where(i => i.id == id).FirstOrDefault();
            return new TariffPlanModel() { name =c.name, id =c.id, CanConnectThisTar=c.CanConnectThisTar, costChangeTar=c.costChangeTar, costOneMinCallCity=c.costOneMinCallCity, CostOneMinCallInternation=c.CostOneMinCallInternation, costOneMinCallOutCity =c.costOneMinCallOutCity, intGB=c.intGB, isPhysTar=c.isPhysTar, SMS=c.SMS, subscriptionFee=c.subcriptionFee };
        }
        public SMSModel GetItemSMS(int id)
        {
            Sms c = db.Sms.ToList().Where(i => i.id == id).FirstOrDefault();
            return new SMSModel() { dateSms =c.dateSms, idClient=c.idClient, id =c.id, recipientSms =c.recipientSms ,textSms =c.textSms};
        }
        public CallModel GetItemCall(int id)
        {
            Call c = db.Call.ToList().Where(i => i.id == id).FirstOrDefault();
            return new CallModel() { id=c.id, idClient=c.idClient, callType =c.callType, dateCall=c.dateCall, numberWasCall=c.numberWasCall, timeTalk=c.timeTalk };
        }
        //СОЗДАНИЕ ЗАПИСИ В БАЗЕ ПО МОДЕЛИ
        public void CreateClient(ClientModel p)
        {
            db.Client.Add(new Client() { id =p.id, balance =p.balance, isPhysCl=p.isPhysCl, password =p.password, phoneNumber =p.phoneNumber });
            Save();
        }
        public void CreateLegalPerson(LegalPersonModel p)
        {
            db.LegalPerson.Add(new LegalPerson() { id =p.id, ITN =p.ITN, legalAdress = p.legalAdress, name =p.name, startDate=p.startDate});
            Save();
        }
        public void CreatePhysPerson(PhysicalPersonModel p)
        {
            db.PhysicalPerson.Add(new PhysicalPerson() { name=p.name, id=p.id, dateOfBirth=p.dateOfBirth, numberPassport=p.numberPassport, surname =p.surname });
            Save();
        }
        //ОБНОВЛЕНИЕ ЗАПИСЕЙ В БАЗЕ
        public void UpdateBalanceClient(ClientModel c,int rubls)
        {
            Client client = db.Client.Find(c.id);
            client.balance = client.balance +  rubls;
            Save();
        }
        public void UpdateClient(ClientModel c)
        {
            Client client = db.Client.Find(c.id);
            client.balance = c.balance;
            client.isPhysCl = c.isPhysCl;
            client.password = c.password;
            client.phoneNumber = c.phoneNumber;
            Save();
        }
        public void UpdatePhysicalPerson(PhysicalPersonModel p)
        {
            PhysicalPerson physical = db.PhysicalPerson.Find(p.id);
            physical.name = p.name;
            physical.numberPassport = p.numberPassport;
            physical.surname = p.surname;
            physical.dateOfBirth = p.dateOfBirth;
            Save();
        }
        public void UpdateLegalPerson(LegalPersonModel l)
        {
            LegalPerson legal = db.LegalPerson.Find(l.id);
            legal.ITN = l.ITN;
            legal.legalAdress = l.legalAdress;
            legal.name = l.name;
            legal.startDate = l.startDate;
            Save();
        }

        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
/*
            < ColumnDefinition Width = "0.63*" />
 
             < ColumnDefinition Width = "0.15*" />
  
              < ColumnDefinition Width = "*" />
   
               < ColumnDefinition Width = "0.1*" />*/
