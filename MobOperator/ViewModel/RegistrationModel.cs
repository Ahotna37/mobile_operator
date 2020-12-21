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
   public class RegistrationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IBeginWindowCodeBehind _BeginCodeBehind;

        private string _textBoxNameText;
        private string _textBoxSurNameText;
        private string _textBoxDateOfBirthText;
        private string _textBoxNumberPassportText;
        private string _textBoxPasswordPhysicalText;
        private string _textBoxNameOrganizationText;
        private string _textBoxLegalAdressText;
        private string _textBoxITNText;
        private string _textBoxStartWorkText;
        private string _textBoxPasswordLegalText;


        private int idUser;
        DbOperation dbOperation = new DbOperation();
        List<ClientModel> allClients;
        ClientModel client;
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
            if (!string.IsNullOrWhiteSpace( _textBoxNameText) )
            {
                CreatePhysPerson(_textBoxNameText, _textBoxSurNameText, _textBoxDateOfBirthText, _textBoxNumberPassportText, _textBoxPasswordPhysicalText);
            }
            if ( !string.IsNullOrWhiteSpace( _textBoxNameOrganizationText) )
            {
                CreateLegalPerson(_textBoxNameOrganizationText, _textBoxLegalAdressText,_textBoxPasswordLegalText, _textBoxITNText, _textBoxStartWorkText);
            }
            idUser = client.id;
            _BeginCodeBehind.LoadView(ViewTypeBegin.MainWindow);
        }
        public int IdUser
        {
            get => idUser;
            set
            {
                idUser = value;
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TextBoxNameText
        {
            get => _textBoxNameText;
            set
            {
                _textBoxNameText = value;
                OnPropertyChanged(nameof(_textBoxNameText));
            }
        }
        public string TextBoxSurNameText
        {
            get => _textBoxSurNameText;
            set
            {
                _textBoxSurNameText = value;
                OnPropertyChanged(nameof(_textBoxSurNameText));
            }
        }
        public string TextBoxDateOfBirthText
        {
            get => _textBoxDateOfBirthText;
            set
            {
                _textBoxDateOfBirthText = value;
                OnPropertyChanged(nameof(_textBoxDateOfBirthText));
            }
        }
        public string TextBoxNumberPassportText
        {
            get => _textBoxNumberPassportText;
            set
            {
                _textBoxNumberPassportText = value;
                OnPropertyChanged(nameof(_textBoxNumberPassportText));
            }
        }
        public string TextBoxPasswordPhysicalText
        {
            get => _textBoxPasswordPhysicalText;
            set
            {
                _textBoxPasswordPhysicalText = value;
                OnPropertyChanged(nameof(_textBoxPasswordPhysicalText));
            }
        }
        public string TextBoxNameOrganizationText
        {
            get => _textBoxNameOrganizationText;
            set
            {
                _textBoxNameOrganizationText = value;
                OnPropertyChanged(nameof(_textBoxNameOrganizationText));
            }
        }
        public string TextBoxLegalAdressText
        {
            get => _textBoxLegalAdressText;
            set
            {
                _textBoxLegalAdressText = value;
                OnPropertyChanged(nameof(_textBoxLegalAdressText));
            }
        }
        public string TextBoxITNText
        {
            get => _textBoxITNText;
            set
            {
                _textBoxITNText = value;
                OnPropertyChanged(nameof(_textBoxITNText));
            }
        }
        public string TextBoxStartWorkText
        {
            get => _textBoxStartWorkText;
            set
            {
                _textBoxStartWorkText = value;
                OnPropertyChanged(nameof(_textBoxStartWorkText));
            }
        }
        public string TextBoxPasswordLegalText
        {
            get => _textBoxPasswordLegalText;
            set
            {
                _textBoxPasswordLegalText = value;
                OnPropertyChanged(nameof(_textBoxPasswordLegalText));
            }
        }

        public void CreatePhysPerson(string _textBoxNameText, string _textBoxSurNameText, string _textBoxDateOfBirthText, string _textBoxNumberPassportText, string _textBoxPasswordPhysicalText)
        {
            allClients = dbOperation.GetAllClients();
            ClientModel lastClient = allClients.Last();
            //DateTime dateTime = new DateTime();
            //dateTime = dateTime.ToLocalTime();
            client = new ClientModel() {
                balance = 0,
                dateConnect = DateTime.Now,
                startDate = null,
                //id = (lastClient.id + 1),
                isPhysCl = true,
                password = _textBoxPasswordPhysicalText,
                phoneNumber =  Convert.ToString(Convert.ToDouble( lastClient.phoneNumber) + 1),
                dateOfBirth = Convert.ToDateTime(_textBoxDateOfBirthText),
                name = _textBoxNameText,
                numberPassport = _textBoxNumberPassportText,
                surname = _textBoxSurNameText,
                freeGB = 0,
                freeMin = 0,
                freeSms = 0
            };
            dbOperation.CreateClient(client);
            allClients = dbOperation.GetAllClients();
            client.id = allClients.Last().id;
        }
        public void CreateLegalPerson(string _textBoxNameOrganizationText, string _textBoxLegalAdressText, string _textBoxPasswordLegalText, string _textBoxITNText, string _textBoxStartWorkText)
        {
            allClients = dbOperation.GetAllClients();
            ClientModel lastClient = allClients.Last();
            DateTime dateTime = new DateTime();
            dateTime = dateTime.ToLocalTime();
            client = new ClientModel() {
                balance = 0,
                dateConnect = dateTime,
                id = (lastClient.id + 1),
                dateOfBirth = null,
                isPhysCl = false,
                password = _textBoxPasswordLegalText,
                phoneNumber = Convert.ToString(Convert.ToDouble(lastClient.phoneNumber) + 1),
                ITN = _textBoxITNText,
                legalAdress = _textBoxLegalAdressText,
                name = _textBoxNameOrganizationText,
                startDate = Convert.ToDateTime(_textBoxStartWorkText),
                freeGB = 0,
                freeMin = 0,
                freeSms = 0
            };
            dbOperation.CreateClient(client);
        }

    }
}
