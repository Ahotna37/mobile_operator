using BLL;
using BLL.Models;
using GalaSoft.MvvmLight.Command;
using MobOperator.View;
using System;
using System.ComponentModel;

namespace MobOperator.ViewModel
{
    public class CreateSmsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        //private IBeginWindowCodeBehind _BeginCodeBehind;


        DbOperation dbOperation = new DbOperation();
        int idUser;

        private string _textBoxRecipientSms;
        private string _textBoxDateSms;
        private string _textBoxTextSMS;
        private string _comboBoxTypeCallSelected;
        private string _comboBoxTypeCallItems;
        private string _comboBoxWhoSmsSelected;
        private IMainWindowsCodeBehind CodeBehind;
        private RelayCommand loadCreateSmsInDb;
        public CreateSmsVM(int IdUser, IMainWindowsCodeBehind codeBehin)
        {
            CodeBehind = codeBehin;
            idUser = IdUser;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string TextBoxRecipientSms
        {
            get => _textBoxRecipientSms;
            set
            {
                _textBoxRecipientSms = value;
                OnPropertyChanged(nameof(_textBoxRecipientSms));
            }
        }
        public string TextBoxDateSms
        {
            get => _textBoxDateSms;
            set
            {
                _textBoxDateSms = value;
                OnPropertyChanged(nameof(_textBoxDateSms));
            }
        }
        public string TextBoxTextSMS
        {
            get => _textBoxTextSMS;
            set
            {
                _textBoxTextSMS = value;
                OnPropertyChanged(nameof(TextBoxTextSMS));
            }
        }
       
        public RelayCommand LoadCreateSmsInDb
        {
            get
            {

                return loadCreateSmsInDb = loadCreateSmsInDb ??
                  new RelayCommand(OutCreateSms, true);
            }
        }
        public string ComboBoxWhoSmsSelected
        {
            get => _comboBoxWhoSmsSelected;
            set
            {
                _comboBoxWhoSmsSelected = value;
                OnPropertyChanged(nameof(ComboBoxWhoSmsSelected));
            }
        }
        private void OutCreateSms()
        {
            MakeSms(idUser);
             CodeBehind.LoadView(ViewType.CallAndSms);
           
        }

        private void MakeSms(int idUserForCall)
        {
            var client = dbOperation.GetItemClient(idUserForCall);
            double costSms = 0;
            var activeTariff = dbOperation.GetActiveTariff(idUserForCall);
            string incomingCallText = ComboBoxWhoSmsSelected;
            bool incomingSms;
            if (incomingCallText.Trim() == "Исходящий")
            {
                incomingSms = true;
            }
            else
            {
                incomingSms = false;
            }
            if (client.freeSms == 0)
            {
                costSms = Convert.ToDouble((Convert.ToDouble(activeTariff.costSms)));
                dbOperation.UpdateBalanceClient(idUserForCall, Convert.ToInt32(costSms));
            }
            else
               if (client.freeSms > 0)
            {
                dbOperation.UpdateFreeSmsForClient(idUser);
            }
            SMSModel createSmsModel = new SMSModel()
            {
                costSMS = Convert.ToDecimal( costSms),
                dateSms = Convert.ToDateTime(TextBoxDateSms),
                idClient = idUser, 
                recipientSms = TextBoxRecipientSms,
                textSms = TextBoxTextSMS, 
                incomingSms = incomingSms

            };
            dbOperation.CreateSms(createSmsModel);

        }
    }


}
