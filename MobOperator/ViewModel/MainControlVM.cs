using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobOperator.ViewModel
{
    class MainControlVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;
        DbOperation dbOperation = new DbOperation();
        List<ClientModel> allClients;
        private ClientModel client;
        public string _labelMinUser;
        public string _labelInternetUser;
        public string _labelSMSPhoneUser;
        public string _labelTimeToUpdate;
        public string _labelBalanceUser;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //ctor
        public MainControlVM(int IdUser)
        {
            /*            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));
                        _MainCodeBehind = codeBehind;*/
            client = dbOperation.GetItemClient(IdUser);
            LabelMinOst =  Convert.ToString( client.freeMin);
            LabelInternetOst = Convert.ToString(client.freeGB);
            LabelSMSOst = Convert.ToString(client.freeSms);
            int startConnect = Convert.ToDateTime( dbOperation.GetActiveConnectTariffDate(IdUser)).Day;
            int date = DateTime.Now.Day;
            int month = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            LabelTimeToUpdate = "До обновления " + (month - date + startConnect) + " дней";
            LabelBalanceUser = "Баланс: " + Convert.ToString(client.balance);
        }

        public string LabelMinOst
        {
            get => _labelMinUser;
            set
            {
                _labelMinUser = value;
                OnPropertyChanged(nameof(LabelMinOst));
            }
        }
        public string LabelInternetOst
        {
            get => _labelInternetUser;
            set
            {
                _labelInternetUser = value;
                OnPropertyChanged(nameof(LabelInternetOst));
            }
        }
        public string LabelSMSOst
        {
            get => _labelSMSPhoneUser;
            set
            {
                _labelSMSPhoneUser = value;
                OnPropertyChanged(nameof(LabelSMSOst));
            }
        }

        public string LabelTimeToUpdate
        {
            get => _labelTimeToUpdate;
            set
            {
                _labelTimeToUpdate = value;
                OnPropertyChanged(nameof(LabelTimeToUpdate));
            }
        }
        public string LabelBalanceUser
        {
            get => _labelBalanceUser;
            set
            {
                _labelBalanceUser = value;
                OnPropertyChanged(nameof(LabelBalanceUser));
            }
        }
    }
}
