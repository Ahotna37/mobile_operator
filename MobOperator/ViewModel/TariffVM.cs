using BLL;
using BLL.Models;
using Caliburn.Micro;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobOperator.ViewModel
{
    class TariffVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind CodeBehind;
        DbOperation dbOperation = new DbOperation();

        private string _labelCostTariff;
        private string _labelFreeMinInMonth;
        private string _labelFreeInternetInMonth;
        private string _labelFreeSmsInMonth;
        private string _labelOneMinCity;
        private string _labelOneMinOutCity;
        private string _labelOneMinInternation;
        private string _charachteristicTariff;
        private string _labelCostSms;
        private bool _tariffChangeButtonsEnabled;
        private TariffPlanModel _listViewTariffSelected;
        int idUser;
        public BindableCollection<TariffPlanModel> TariffPlan { get; set; }
        private RelayCommand loadChangeTariff;
        //ctor
        public TariffVM(int IdUsers)
        {
            idUser = IdUsers;
            ClientModel client = dbOperation.GetItemClient(idUser);
            if(client.isPhysCl == true)
                TariffPlan = new BindableCollection<TariffPlanModel>(dbOperation.GetAllTariffPlanForPhys());
            else
                TariffPlan = new BindableCollection<TariffPlanModel>(dbOperation.GetAllTariffPlanForLegal());
            TariffPlanModel ActiveTariff = dbOperation.GetActiveTariff(idUser);
            ListViewTariffSelected = ActiveTariff;
            //TariffPlanModel tariff = dbOperation.GetItemTariffPlan(ListViewTariffSelected.name);
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void LoadTariff()
        {
            TariffPlanModel newTariff = ListViewTariffSelected;
/*            TariffPlanModel TariffConnected = dbOperation.GetAllServicesConnectedForClient(idUser).Where(i => i.name == extraService.name).FirstOrDefault();
            if (TariffConnected == null)
            {*/
                dbOperation.UpdateBalanceClient(idUser,-newTariff.costChangeTar);
            dbOperation.UpdateConnectTariff(idUser, newTariff.id);
        }

        public RelayCommand LoadChangeTariff
        {
            get
            {
                return loadChangeTariff = loadChangeTariff ??
                  new RelayCommand(LoadTariff, true);
            }
        }
        public TariffPlanModel ListViewTariffSelected
        {
            get => _listViewTariffSelected;
            set
            {
                _listViewTariffSelected = value;
                ChengeAllInWindow(value);
                TariffPlanModel ActiveTariff = dbOperation.GetActiveTariff(idUser);
                if (ListViewTariffSelected.name.Trim() == ActiveTariff.name.Trim())
                {
                    TariffChangeButtonsEnabled = false;
                }
                else
                {
                    TariffChangeButtonsEnabled = true;
                }
                OnPropertyChanged(nameof(ListViewTariffSelected));
            }
        }

        public bool TariffChangeButtonsEnabled
        {
            get => _tariffChangeButtonsEnabled;
            set
            {
                    _tariffChangeButtonsEnabled = value;
                    OnPropertyChanged(nameof(TariffChangeButtonsEnabled));
            }
        }
        private void ChengeAllInWindow(TariffPlanModel tariff)
        {

            CharachteristicTariff = "Характеристики";
            LabelCostSms = "Стоимость СМС: " + tariff.costSms;
            LabelCostTariff = "Стоимость подключения: " + tariff.subscriptionFee;
            LabelFreeMinInMonth = "Бесплатные минуты: " + tariff.freeMinuteForMonth;
            LabelFreeInternetInMonth = "Интернет:" + tariff.intGB + " ГБ";
            LabelFreeSmsInMonth = "Бесплатных СМС: " + tariff.SMS;
            LabelOneMinCity = "Минута разговора: " + tariff.costOneMinCallCity;
            LabelOneMinOutCity = "Минута разговора по России: " + tariff.costOneMinCallOutCity;
            LabelOneMinInternation = "Минута разговора в другую страну: " + tariff.CostOneMinCallInternation;

        }
        public string CharachteristicTariff
        {
            get => _charachteristicTariff;
            set
            {
                _charachteristicTariff = value;
                OnPropertyChanged(nameof(CharachteristicTariff));
            }
        }
        public string LabelCostTariff
        {
            get => _labelCostTariff;
            set
            {
                _labelCostTariff = value;
                OnPropertyChanged(nameof(LabelCostTariff));
            }
        }
        public string LabelCostSms
        {
            get => _labelCostSms;
            set
            {
                _labelCostSms = value;
                OnPropertyChanged(nameof(LabelCostSms));
            }
        }
        public string LabelFreeMinInMonth
        {
            get => _labelFreeMinInMonth;
            set
            {
                _labelFreeMinInMonth = value;
                OnPropertyChanged(nameof(LabelFreeMinInMonth));
            }
        }
        public string LabelFreeInternetInMonth
        {
            get => _labelFreeInternetInMonth;
            set
            {
                _labelFreeInternetInMonth = value;
                OnPropertyChanged(nameof(LabelFreeInternetInMonth));
            }
        }
        public string LabelFreeSmsInMonth
        {
            get => _labelFreeSmsInMonth;
            set
            {
                _labelFreeSmsInMonth = value;
                OnPropertyChanged(nameof(LabelFreeSmsInMonth));
            }
        }
        public string LabelOneMinCity
        {
            get => _labelOneMinCity;
            set
            {
                _labelOneMinCity = value;
                OnPropertyChanged(nameof(LabelOneMinCity));
            }
        }
        public string LabelOneMinOutCity
        {
            get => _labelOneMinOutCity;
            set
            {
                _labelOneMinOutCity = value;
                OnPropertyChanged(nameof(LabelOneMinOutCity));
            }
        }
        public string LabelOneMinInternation
        {
            get => _labelOneMinInternation;
            set
            {
                _labelOneMinInternation = value;
                OnPropertyChanged(nameof(LabelOneMinInternation));
            }
        }
    }

}
