using BLL.Models;
using DAL;
using DAL.Entities;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Service.Reports;
//using Ubiety.Dns.Core;

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
/*        public List<PhysicalPersonModel> GetAllPhysicalPersons()
        {
            return db.PhysicalPerson.ToList().Select(i => new PhysicalPersonModel(i)).ToList();
        }
        public List<LegalPersonModel> GetAllLegalPersons()
        {
            return db.LegalPerson.ToList().Select(i => new LegalPersonModel(i)).ToList();
        }*/
        public List<ExtraServiceModel> GetAllExtraServices()
        {
            return db.ExtraService.ToList().Select(i => new ExtraServiceModel(i)).ToList();
        }
        public List<AddBalanceEntityModel> GetAllAddBalance()
        {
            return db.AddBalance.ToList().Select(i => new AddBalanceEntityModel(i)).ToList();
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
        public List<CallModel> GetCallClient(int idClient)
        {
            return db.Call.ToList().Select(i => new CallModel(i)).Where(i => i.idClient == idClient).ToList();
        }
        public List<SMSModel> GetSmsClient(int idClient)
        {
            return db.Sms.ToList().Select(i => new SMSModel(i)).Where(i => i.idClient == idClient).ToList();
        }
        //ВОЗВРАЩЕНИЕ КОНКРЕТНЫХ ЭЛЕМЕНТОВ ПО ID
        public ClientModel GetItemClient(int id)
        {
            Client c = db.Client.ToList().Where(i => i.id == id).FirstOrDefault();
            return new ClientModel() { 
                //id = c.id,
                dateOfBirth = c.dateOfBirth,
                nameOrganisation = c.nameOrganization,
                ITN = c.ITN, legalAdress = c.legalAdress,
                startDate = c.startDate,
                name = c.name,
                numberPassport = c.numberPassport,
                surname = c.surName,
                balance = c.balance,
                dateConnect = c.dateConnect,
                isPhysCl = c.isPhysCl,
                password = c.password ,
                phoneNumber = c.phoneNumber,
                freeGB = c.freeGB,
                freeMin=c.freeMin,
                freeSms =c.freeSms  };
        }
/*        public PhysicalPersonModel GetItemPhysicalPerson(int id)
        {
            PhysicalPerson c = db.PhysicalPerson.ToList().Where(i => i.id == id).FirstOrDefault();
            return new PhysicalPersonModel() { id = c.id, dateOfBirth =c.dateOfBirth, name=c.name, numberPassport =c.numberPassport, surname =c.surname };
        }
        public LegalPersonModel GetItemLegalPerson(int id)
        {
            LegalPerson c = db.LegalPerson.ToList().Where(i => i.id == id).FirstOrDefault();
            return new LegalPersonModel() { name =c.name, id = c.id, ITN = c.ITN, legalAdress =c.legalAdress, startDate =c.startDate };
        }*/
        public ExtraServiceModel GetItemExtraService(int id)
        {
            ExtraService c = db.ExtraService.ToList().Where(i => i.id == id).FirstOrDefault();
            return new ExtraServiceModel() { CanConnectThisSer =c.CanConnectThisSer, id =c.id, name =c.name, description =c.description, subscFee =c.subscFee };
        }
        public TariffPlanModel GetItemTariffPlan(int id)
        {
            TariffPlan c = db.TariffPlan.ToList().Where(i => i.id == id).FirstOrDefault();
            return new TariffPlanModel() { freeMinuteForMonth =c.freeMinuteForMonth, name =c.name, id =c.id, CanConnectThisTar=c.CanConnectThisTar, costChangeTar=c.costChangeTar, costOneMinCallCity=c.costOneMinCallCity, CostOneMinCallInternation=c.CostOneMinCallInternation, costOneMinCallOutCity =c.costOneMinCallOutCity, intGB=c.intGB, isPhysTar=c.isPhysTar, SMS=c.SMS, subscriptionFee=c.subcriptionFee };
        }
        public SMSModel GetItemSMS(int id)
        {
            Sms c = db.Sms.ToList().Where(i => i.id == id).FirstOrDefault();
            return new SMSModel() { dateSms =c.dateSms, idClient=c.idClient, id =c.id, recipientSms =c.recipientSms ,textSms =c.textSms};
        }
        public CallModel GetItemCall(int id)
        {
            Call c = db.Call.ToList().Where(i => i.id == id).FirstOrDefault();
            return new CallModel() {  id=c.id, idClient=c.idClient, callType =c.callType, dateCall=c.dateCall, numberWasCall=c.numberWasCall, timeTalk=c.timeTalk };
        }

        public TariffPlanModel GetActiveTariff(int idClient)
        {
            ConnectTariff connect = db.ConnectTariff.ToList().Where(i => i.idClient == idClient && i.dateConnectTariffEnd == null).FirstOrDefault();
            TariffPlan tariffPlan = db.TariffPlan.ToList().Where(i => i.id == connect.idTariffPlan).FirstOrDefault();
            return new TariffPlanModel()
            {
                freeMinuteForMonth = tariffPlan.freeMinuteForMonth,
                name = tariffPlan.name,
                id = tariffPlan.id,
                CanConnectThisTar = tariffPlan.CanConnectThisTar,
                costChangeTar = tariffPlan.costChangeTar,
                costOneMinCallCity = tariffPlan.costOneMinCallCity,
                CostOneMinCallInternation = tariffPlan.CostOneMinCallInternation,
                costOneMinCallOutCity = tariffPlan.costOneMinCallOutCity,
                intGB = tariffPlan.intGB,
                isPhysTar = tariffPlan.isPhysTar,
                SMS = tariffPlan.SMS,
                subscriptionFee = tariffPlan.subcriptionFee
            };
        }
        //СОЗДАНИЕ ЗАПИСИ В БАЗЕ ПО МОДЕЛИ
        public void CreateClient(ClientModel p)
        {
            if (p.isPhysCl == true)
            {
                db.Client.Add(new Client() { 
                    //id = p.id,
                    balance = p.balance,
                     startDate=null,
                     ITN = null,
                     legalAdress = null,
                     nameOrganization = null,
                    isPhysCl = p.isPhysCl,
                    password = p.password,
                    phoneNumber = p.phoneNumber,
                    dateConnect =p.dateConnect,
                    freeGB = p.freeGB,
                    freeMin =p.freeMin,
                    freeSms =p.freeSms,
                    name = p.name,
                    surName=p.surname,
                    dateOfBirth = p.dateOfBirth,
                    numberPassport =p.numberPassport });
                
            }
            else
            {
                db.Client.Add(new Client()
                {
                    //id = p.id,
                    balance = p.balance, 
                    dateOfBirth = null,
                    name = null,
                    numberPassport = null, surName = null,
                    isPhysCl = p.isPhysCl,
                    password = p.password,
                    phoneNumber = p.phoneNumber,
                    dateConnect = p.dateConnect,
                    freeGB = p.freeGB,
                    freeMin = p.freeMin,
                    freeSms = p.freeSms,
                    nameOrganization = p.nameOrganisation,
                    legalAdress =p.legalAdress,
                    ITN =p.ITN, 
                    startDate =p.startDate

                });
            }
            Save();
        }
        public void CreateAddBalance(AddBalanceEntityModel add)
        {
            db.AddBalance.Add(new AddBalance()
            {
                CVVBankCard = add.CVVBankCard,
                dateBankCard = add.dateBankCard,
                idClient = add.idClient,
                nameBankCard =add.nameBankCard,
                numberBankCard =add.numberBankCard,
                phoneNumberForAddBalance=add.phoneNumberForAddBalance,
                 SumForAdd = add.SumForAdd
            });
            Save();
        }
        public void CreateCall(CallModel call)
        {
            db.Call.Add(new Call()
            {
                 callType = call.callType,
                costCall = Convert.ToDecimal( call.costCall),
                dateCall = call.dateCall,
                idClient = call.idClient,
                numberWasCall = call.numberWasCall,
                timeTalk = call.timeTalk 
            });
            Save();
        }
        /*        public void CreateLegalPerson(LegalPersonModel p)
                {
                    db.LegalPerson.Add(new LegalPerson() { id =p.id, ITN =p.ITN, legalAdress = p.legalAdress, name =p.name, startDate=p.startDate});
                    Save();
                }
                public void CreatePhysPerson(PhysicalPersonModel p)
                {
                    db.PhysicalPerson.Add(new PhysicalPerson() { name=p.name, id=p.id, dateOfBirth=p.dateOfBirth, numberPassport=p.numberPassport, surname =p.surname });
                    Save();
                }*/
        //ОБНОВЛЕНИЕ ЗАПИСЕЙ В БАЗЕ
        public void UpdateBalanceClient(int idClient,int rubls)
        {
            Client client = db.Client.Find(idClient);
            client.balance = client.balance +  rubls;
            Save();
        }
        public void UpdateFreeMinForClient(int idClient, int min)
        {
            Client client = db.Client.Find(idClient);
            client.freeMin = client.freeMin - min;
            Save();
        }
        /*        public void UpdateClient(ClientModel c)
                {
                    Client client = db.Client.Find(c.id);
                    client.balance = c.balance;
                    client.isPhysCl = c.isPhysCl;
                    client.password = c.password;
                    client.phoneNumber = c.phoneNumber;
                    Save();
                }*/
        /*        public void UpdatePhysicalPerson(PhysicalPersonModel p)
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
                }*/

        public bool Save()
        {
/*            if (db.SaveChanges() > 0) return true;
            return false;*/
            try
            {

                db.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    //Response.Write("Object: " + validationError.Entry.Entity.ToString());
                    //Response.Write("");
                    Console.WriteLine("Object: " + validationError.Entry.Entity.ToString());
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        //Response.(err.ErrorMessage + "");
                        Console.WriteLine(err.ErrorMessage + "");
                        }
                }
            }
            return false;
        }
    }
}
/*
            < ColumnDefinition Width = "0.63*" />
 
             < ColumnDefinition Width = "0.15*" />
  
              < ColumnDefinition Width = "*" />
   
               < ColumnDefinition Width = "0.1*" />*/
