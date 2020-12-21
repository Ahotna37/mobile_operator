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
    class CallAndSmsModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        //private IMainWindowsCodeBehind _MainCodeBehind;
        DbOperation dbOperation = new DbOperation();
        private IMainWindowsCodeBehind CodeBehind;
        private RelayCommand loadCreateCall;
        private RelayCommand loadCreateSms;
        public BindableCollection<CallModel> Call { get; set; }
        public BindableCollection<SMSModel> Sms { get; set; }
        //ctor
        public CallAndSmsModel(int idUser, IMainWindowsCodeBehind codeBehind)
        {
            CodeBehind = codeBehind;
/*            ClientModel clientModel = dbOperation.GetItemClient(idUser);
            TariffPlanModel activeTariff = dbOperation.GetActiveTariff(idUser);*/
            //dbOperation.
            Call = new BindableCollection<CallModel>(dbOperation.GetCallClient(idUser));
            Sms = new BindableCollection<SMSModel>(dbOperation.GetSmsClient(idUser));
        }
        public RelayCommand LoadCreateCall
        {
            get
            {

                return loadCreateCall = loadCreateCall ??
                  new RelayCommand(OutBeginCreateCall, true);
            }
        }
        private void OutBeginCreateCall()
        {
            CodeBehind.LoadView(ViewType.CreateCall);
        }
        public RelayCommand LoadCreateSms
        {
            get
            {

                return loadCreateSms = loadCreateSms ??
                  new RelayCommand(OutBeginCreateSms, true);
            }
        }
        private void OutBeginCreateSms()
        {
            CodeBehind.LoadView(ViewType.CreateSms);
        }
    }
}
