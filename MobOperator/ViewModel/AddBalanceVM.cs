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
    class AddBalanceVM : INotifyPropertyChanged
    {
        private IMainWindowsCodeBehind CodeBehind;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        DbOperation dbOperation = new DbOperation();
        private ClientModel client;

        //Fields
        //private IMainWindowsCodeBehind _MainCodeBehind;
        private string _textBoxNumberPhoneForAddText;
        private string _textBoxNumberBankCardText;
        private string _textBoxNameOfBankCardText;
        private string _textBoxDateBankCardText;
        private string _textBoxCVVText;
        private string _textBoxSumForAddText;
        private string _labelErrorAddBalance;
        BLL.Models.AddBalanceModel addBalance;

        private RelayCommand loadAddBalanceInDb;
        int idUser;

        //ctor
        public AddBalanceVM(int IdUser )
        {
            //client = dbOperation.GetItemClient(IdUser);

                idUser = IdUser;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void LoadAdd()
        {
            if (!string.IsNullOrWhiteSpace(TextBoxCVVText) &&
                !string.IsNullOrWhiteSpace(TextBoxDateBankCardText) &&
                !string.IsNullOrWhiteSpace(TextBoxNameOfBankCardText) &&
                !string.IsNullOrWhiteSpace(TextBoxNumberBankCardText) &&
                !string.IsNullOrWhiteSpace(TextBoxNumberPhoneForAddText) &&
                !string.IsNullOrWhiteSpace(TextBoxSumForAddText))
            {
                addBalance = new BLL.Models.AddBalanceModel()
                {
                    CVVBankCard = Convert.ToInt32(TextBoxCVVText),
                    idClient = idUser,
                    dateBankCard = Convert.ToDateTime(TextBoxDateBankCardText),
                    nameBankCard = TextBoxNameOfBankCardText,
                    numberBankCard = TextBoxNumberBankCardText,
                    phoneNumberForAddBalance = TextBoxNumberPhoneForAddText,
                    SumForAdd = Convert.ToInt32(TextBoxSumForAddText)

                };
                dbOperation.CreateAddBalance(addBalance);
                dbOperation.UpdateBalanceClient(idUser, Convert.ToInt32(TextBoxSumForAddText));
            }
            else
            {
                LabelErrorAddBalance = "Незаполены поля!";
            }
            
            //CodeBehind.LoadView(ViewType.Main);
        }
        public RelayCommand LoadAddBalanceInDb
        {
            get
            {
                return loadAddBalanceInDb = loadAddBalanceInDb ??
                  new RelayCommand(LoadAdd, true);
            }
        }
        public string TextBoxNumberPhoneForAddText
        {
            get => _textBoxNumberPhoneForAddText;
            set
            {
                //LabelErrorAddBalance = "";
                _textBoxNumberPhoneForAddText = value;
                OnPropertyChanged(nameof(_textBoxNumberPhoneForAddText));
            }
        }
        public string TextBoxSumForAddText
        {
            get => _textBoxSumForAddText;
            set
            {
                //LabelErrorAddBalance = "";
                _textBoxSumForAddText = value;
                OnPropertyChanged(nameof(_textBoxSumForAddText));
            }
        }
        public string TextBoxNumberBankCardText
        {
            get => _textBoxNumberBankCardText;
            set
            {
                //LabelErrorAddBalance = "";
                _textBoxNumberBankCardText = value;
                OnPropertyChanged(nameof(_textBoxNumberBankCardText));
            }
        }
        public string LabelErrorAddBalance
        {
            get => _labelErrorAddBalance;
            set
            {
                //LabelErrorAddBalance = "";
                _labelErrorAddBalance = value;
                OnPropertyChanged(nameof(LabelErrorAddBalance));
            }
        }
        public string TextBoxNameOfBankCardText
        {
            get => _textBoxNameOfBankCardText;
            set
            {
                //LabelErrorAddBalance = "";
                _textBoxNameOfBankCardText = value;
                OnPropertyChanged(nameof(_textBoxNameOfBankCardText));
            }
        }
        public string TextBoxDateBankCardText
        {
            get => _textBoxDateBankCardText;
            set
            {
                //LabelErrorAddBalance = "";
                _textBoxDateBankCardText = value;
                OnPropertyChanged(nameof(_textBoxDateBankCardText));
            }
        }
        public string TextBoxCVVText
        {
            get => _textBoxCVVText;
            set
            {
                //LabelErrorAddBalance = "";
                _textBoxCVVText = value;
                OnPropertyChanged(nameof(_textBoxCVVText));
            }
        }
    }
}
