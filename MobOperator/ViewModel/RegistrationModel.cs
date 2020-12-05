using BLL;
using BLL.Models;
using GalaSoft.MvvmLight.Command;
using MobOperator.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobOperator.ViewModel
{
    class RegistrationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IBeginWindowCodeBehind _BeginCodeBehind;

        DbOperation dbOperation = new DbOperation();
        List<ClientModel> allClients;
        List<PhysicalPersonModel> allPhys;
        private RelayCommand loadMainWindow;
        private RelayCommand loadAutorisation;

        //ctor
        public RegistrationModel(IBeginWindowCodeBehind CodeBehindBegin)
        {
            if (CodeBehindBegin == null) throw new ArgumentNullException(nameof(CodeBehindBegin));

            _BeginCodeBehind = CodeBehindBegin;
        }
        public RelayCommand LoadAutorisation
        {
            get
            {
                return loadAutorisation = loadAutorisation ??
                  new RelayCommand(OutAutorisation, true);
            }
        }
        private void OutAutorisation()
        {
            _BeginCodeBehind.LoadView(ViewTypeBegin.Autorisation);
        }
        public RelayCommand LoadMainWindow
        {
            get
            {
                return loadMainWindow = loadMainWindow ??
                  new RelayCommand(OutBeginWindow, true);
            }
        }
        private void OutBeginWindow()
        {
            _BeginCodeBehind.LoadView(ViewTypeBegin.MainWindow);
        }
       public void CreatePhysPerson(string nameNew, string surnameNew, string date, string numberOfPass, string pass)
        {
            allClients = dbOperation.GetAllClients();
            ClientModel lastClient = allClients.Last();
            DateTime dateTime = new DateTime();
            dateTime = dateTime.ToLocalTime();
            ClientModel client = new ClientModel() { balance = 0, dateConnect = dateTime, id = (lastClient.id + 1), isPhysCl = true, password = pass, phoneNumber = (lastClient.phoneNumber + 1) };
            PhysicalPersonModel physicalPerson = new PhysicalPersonModel() { id = lastClient.id + 1, dateOfBirth = Convert.ToDateTime(date), name = nameNew, numberPassport = numberOfPass, surname = surnameNew };
            dbOperation.CreateClient(client);
            dbOperation.CreatePhysPerson(physicalPerson);
        }
        public void CreateLegalPerson(string NameOrganisation, string LegAddres, string pass, string itn, string start)
        {
            allClients = dbOperation.GetAllClients();
            ClientModel lastClient = allClients.Last();
            DateTime dateTime = new DateTime();
            dateTime = dateTime.ToLocalTime();
            ClientModel client = new ClientModel() { balance = 0, dateConnect = dateTime, id = (lastClient.id + 1), isPhysCl = false, password = pass, phoneNumber = (lastClient.phoneNumber + 1) };
            LegalPersonModel legalPerson = new LegalPersonModel() { id = lastClient.id + 1, ITN = itn, legalAdress = LegAddres, name = NameOrganisation, startDate = Convert.ToDateTime(start) };
            dbOperation.CreateClient(client);
            dbOperation .CreateLegalPerson(legalPerson);
        }

    }
}
