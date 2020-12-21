using BLL;
using BLL.Models;
using GalaSoft.MvvmLight.Command;
using MobOperator.View;
using System;
using System.ComponentModel;

namespace MobOperator.ViewModel
{
    public class CreateCallModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        //private IBeginWindowCodeBehind _BeginCodeBehind;


        DbOperation dbOperation = new DbOperation();
        int idUser;

        private string _textBoxWhoWasCall;
        private string _textBoxDateCall;
        private string _textBoxTimeTalk;
        private string _comboBoxTypeCallSelected;
        private string _comboBoxTypeCallItems;
        private IMainWindowsCodeBehind CodeBehind;
        private RelayCommand loadCreateCallInDb;
        public CreateCallModel(int IdUser, IMainWindowsCodeBehind codeBehin)
        {
            CodeBehind = codeBehin;
            idUser = IdUser;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string TextBoxWhoWasCall
        {
            get => _textBoxWhoWasCall;
            set
            {
                _textBoxWhoWasCall = value;
                OnPropertyChanged(nameof(_textBoxWhoWasCall));
            }
        }
        public string TextBoxDateCall
        {
            get => _textBoxDateCall;
            set
            {
                _textBoxDateCall = value;
                OnPropertyChanged(nameof(_textBoxDateCall));
            }
        }
        public string TextBoxTimeTalk
        {
            get => _textBoxTimeTalk;
            set
            {
                _textBoxTimeTalk = value;
                OnPropertyChanged(nameof(_textBoxTimeTalk));
            }
        }
        public string ComboBoxTypeCallSelected
        {
            get => _comboBoxTypeCallSelected;
            set
            {
                _comboBoxTypeCallSelected = value;
                OnPropertyChanged(nameof(_comboBoxTypeCallSelected));
            }
        }

        public string ComboBoxTypeCallItems
        {
            get => _comboBoxTypeCallItems;
            set
            {
                _comboBoxTypeCallItems = value;
                OnPropertyChanged(nameof(_comboBoxTypeCallItems));
            }
        }
        public RelayCommand LoadCreateCallInDb
        {
            get
            {

                return loadCreateCallInDb = loadCreateCallInDb ??
                  new RelayCommand(OutCreateCall, true);
            }
        }
        private void OutCreateCall()
        {
            MakeCall(idUser);
             CodeBehind.LoadView(ViewType.CallAndSms);
           
        }
        
        private void MakeCall(int idUserForCall)
        {
            var client = dbOperation.GetItemClient(idUserForCall);
            int callType = -1;
            double costCall = -1;
            var activeTariff = dbOperation.GetActiveTariff(idUserForCall);
            switch (ComboBoxTypeCallSelected.ToString().Trim())
            {
                case "Городской":
                    callType = 1;
                    break;
                case "Междугородний":
                    callType = 2;
                    break;
                case "В другую страну":
                    callType = 3;
                    break;
            }

            if (client.freeMin == 0)
            {
                switch (callType)
                {
                    case 1:
                        costCall = Convert.ToDouble(-(Convert.ToDouble( TextBoxTimeTalk) * Convert.ToDouble(activeTariff.costOneMinCallCity)));
                        dbOperation.UpdateBalanceClient(idUserForCall, Convert.ToInt32(costCall));
                        break;
                    case 2:
                        costCall = Convert.ToDouble(-(Convert.ToDouble(TextBoxTimeTalk) * Convert.ToDouble(activeTariff.costOneMinCallOutCity)));
                        dbOperation.UpdateBalanceClient(idUserForCall, Convert.ToInt32(costCall));
                        break;
                    case 3:
                        costCall = Convert.ToDouble(-(Convert.ToDouble(TextBoxTimeTalk) * Convert.ToDouble(activeTariff.CostOneMinCallInternation)));
                        dbOperation.UpdateBalanceClient(idUserForCall, Convert.ToInt32(costCall));
                        break;
                }
            }
            else
               if (client.freeMin > 0)
            {
                var timeFree = client.freeMin - Convert.ToDouble(TextBoxTimeTalk);
                if (timeFree >= 0)
                {
                    costCall = 0;
                    dbOperation.UpdateFreeMinForClient(idUserForCall, Convert.ToInt32(TextBoxTimeTalk));
                }
                else
                    if (timeFree < 0)
                {
                    dbOperation.UpdateFreeMinForClient(idUserForCall, Convert.ToInt32(client.freeMin - client.freeMin));
                    switch (callType)
                    {
                        case 1:
                            costCall = Convert.ToDouble(timeFree * Convert.ToDouble(activeTariff.costOneMinCallCity));
                            dbOperation.UpdateBalanceClient(idUserForCall, Convert.ToInt32(costCall));
                            break;
                        case 2:
                            costCall = Convert.ToDouble(timeFree * Convert.ToDouble(activeTariff.costOneMinCallOutCity));
                            dbOperation.UpdateBalanceClient(idUserForCall, Convert.ToInt32(costCall));
                            break;
                        case 3:
                            costCall = Convert.ToDouble(timeFree * Convert.ToDouble(activeTariff.CostOneMinCallInternation));
                            dbOperation.UpdateBalanceClient(idUserForCall, Convert.ToInt32(costCall));
                            break;
                    }
                }
            }
            CallModel createCallModel = new CallModel()
            {
                callType = callType,
                costCall = costCall,
                dateCall = Convert.ToDateTime(TextBoxDateCall),
                idClient = idUser,
                numberWasCall = TextBoxWhoWasCall,
                timeTalk = Convert.ToInt32(TextBoxTimeTalk)
            };
            dbOperation.CreateCall(createCallModel);
            
        }
    }


}
