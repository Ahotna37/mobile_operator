using BLL;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobOperator.View;
using BLL.Models;

namespace MobOperator.ViewModel
{
    public class MainWindowModel
    {
        public IMainWindowsCodeBehind CodeBehind { get; set; }
        private ClientModel client;
        DbOperation dbOperation = new DbOperation();
        public string _labelNameUser;
        public string _labelBalanceUser;
        public string _labelNumberPhoneUser;
        public static int idUserNow;
        //ctor
        public MainWindowModel(int IdUserFromAutorizaton)
        {
            IdUserNow = IdUserFromAutorizaton;
            client = dbOperation.GetItemClient(IdUserNow);
            //string st = TextBoxPasswordText;
            if (client.isPhysCl == true)
            {
                _labelNameUser = client.name.Trim() + " " + client.surname.Trim();
            }
            else
            {
                _labelNameUser = client.nameOrganisation.Trim();
            }
            _labelNumberPhoneUser ="Номер телефона: " + client.phoneNumber;
            _labelBalanceUser = "Баланс: " + Convert.ToString(client.balance);
            //_labelTariffUser= tariff
        }
        private RelayCommand loadMainWindow;
        private RelayCommand loadAddBalance;
        private RelayCommand loadCallAndSms;
        private RelayCommand loadTariff;
        private RelayCommand loadService;
        public RelayCommand LoadMainWindow
        {
            get
            {
                return loadMainWindow = loadMainWindow ??
                  new RelayCommand(OutMainWindow, true);
            }
        }
        private void OutMainWindow()
        {
            
            CodeBehind.LoadView(ViewType.Main);
        }
        public RelayCommand LoadAddBalance
        {
            get
            {
                return loadAddBalance = loadAddBalance ??
                  new RelayCommand(OutAddBalance, true);
            }
        }
        private void OutAddBalance()
        {
            CodeBehind.LoadView(ViewType.AddBalance);
        }
        public RelayCommand LoadCallAndSms
        {
            get
            {
                return loadCallAndSms = loadCallAndSms ??
                  new RelayCommand(OutCallAndSms, true);
            }
        }
        private void OutCallAndSms()
        {
            CodeBehind.LoadView(ViewType.CallAndSms);
        }
        public RelayCommand LoadTariff
        {
            get
            {
                return loadTariff = loadTariff ??
                  new RelayCommand(OutTariff, true);
            }
        }
        private void OutTariff()
        {
            CodeBehind.LoadView(ViewType.Tariff);
        }
        public RelayCommand LoadService
        {
            get
            {
                return loadService = loadService ??
                  new RelayCommand(OutService, true);
            }
        }
        private void OutService()
        {
            CodeBehind.LoadView(ViewType.Service);
        }
        public string LabelNameUser
        {
            get => _labelNameUser;
        }
        public string LabelBalanceUser
        {
            get => _labelBalanceUser;
        }
        public string LabelNumberPhoneUser
        {
            get => _labelNumberPhoneUser;
        }
        public int IdUserNow
        {
            get => idUserNow;
            set
            {
                idUserNow = value;
            }
        }
    }
}
