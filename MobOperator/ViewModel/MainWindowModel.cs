using BLL;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobOperator.View;

namespace MobOperator.ViewModel
{
    public class MainWindowModel
    {
        /*        private string countMinutes;
                public MainWindowModel()
                {
                    countMinutes = "100 минут";
                }
                public string CountMinutes { get { return countMinutes; } }*/

        public IMainWindowsCodeBehind CodeBehind { get; set; }
        

        //ctor
        public MainWindowModel()
        {
            
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
    }
}
