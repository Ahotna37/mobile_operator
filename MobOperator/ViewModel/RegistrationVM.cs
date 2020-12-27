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
   public class RegistrationVM : INotifyPropertyChanged
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
        private string _labelErrorReg;

        private int idUser;
        DbOperation dbOperation = new DbOperation();
        List<ClientModel> allClients;
        ClientModel client;
        private RelayCommand loadMainWindow;
        private RelayCommand loadAutorisation;

        //ctor
        public RegistrationVM(IBeginWindowCodeBehind CodeBehindBegin)
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


            //DateTime date = Convert.ToDateTime(TextBoxDateOfBirthText);
            DateTime dDate;
            if (!string.IsNullOrWhiteSpace(TextBoxNameText) &&
                !string.IsNullOrWhiteSpace(TextBoxSurNameText) &&
                !string.IsNullOrWhiteSpace(TextBoxDateOfBirthText) &&
                !string.IsNullOrWhiteSpace(TextBoxNumberPassportText) &&
                !string.IsNullOrWhiteSpace(TextBoxPasswordPhysicalText) &&
                string.IsNullOrWhiteSpace(TextBoxNameOrganizationText) &&
                    string.IsNullOrWhiteSpace(TextBoxLegalAdressText) &&
                    string.IsNullOrWhiteSpace(TextBoxPasswordLegalText) &&
                    string.IsNullOrWhiteSpace(TextBoxITNText) &&
                    string.IsNullOrWhiteSpace(TextBoxStartWorkText))
            {
                if (DateTime.TryParse(TextBoxDateOfBirthText, out dDate))
                {
                    if (TextBoxPasswordPhysicalText.Length>=6)
                    {
                        CreatePhysPerson(TextBoxNameText, TextBoxSurNameText, TextBoxDateOfBirthText, TextBoxNumberPassportText, TextBoxPasswordPhysicalText);
                        idUser = client.id;
                        _BeginCodeBehind.LoadView(ViewTypeBegin.MainWindow);
                    }
                    else
                    {
                        LabelErrorReg = "Пароль слишком короткий (минимум 6 символов)";
                    }
                    
                }
                else
                {
                    LabelErrorReg = "Формат времени неверно указан (дд/ММ/гггг)";
                }

            }
            else
            {
                if (string.IsNullOrWhiteSpace(TextBoxNameText) &&
                string.IsNullOrWhiteSpace(TextBoxSurNameText) &&
                string.IsNullOrWhiteSpace(TextBoxDateOfBirthText) &&
                string.IsNullOrWhiteSpace(TextBoxNumberPassportText) &&
                string.IsNullOrWhiteSpace(TextBoxPasswordPhysicalText) &&
                !string.IsNullOrWhiteSpace(TextBoxNameOrganizationText) &&
                    !string.IsNullOrWhiteSpace(TextBoxLegalAdressText) &&
                    !string.IsNullOrWhiteSpace(TextBoxPasswordLegalText) &&
                    !string.IsNullOrWhiteSpace(TextBoxITNText) &&
                    !string.IsNullOrWhiteSpace(TextBoxStartWorkText))
                {

                    if (DateTime.TryParse(TextBoxStartWorkText, out dDate))
                    {
                        if (TextBoxPasswordLegalText.Length >= 6)
                        {
                            CreateLegalPerson(TextBoxNameOrganizationText, TextBoxLegalAdressText, TextBoxPasswordLegalText, TextBoxITNText, TextBoxStartWorkText);
                            idUser = client.id;
                            _BeginCodeBehind.LoadView(ViewTypeBegin.MainWindow);
                        }
                        else
                        {
                            LabelErrorReg = "Пароль слишком короткий (минимум 6 символов)";
                        }

                    }
                    else
                    {
                        LabelErrorReg = "Формат времени неверно указан (дд/ММ/гггг)";
                    }
                    
                }
                else
                {
                    LabelErrorReg = "Незаполены поля!";
                }
            }

            
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
                OnPropertyChanged(nameof(TextBoxNameText));
            }
        }
        public string TextBoxSurNameText
        {
            get => _textBoxSurNameText;
            set
            {
                _textBoxSurNameText = value;
                OnPropertyChanged(nameof(TextBoxSurNameText));
            }
        }
        public string TextBoxDateOfBirthText
        {
            get => _textBoxDateOfBirthText;
            set
            {
                LabelErrorReg = "";
                _textBoxDateOfBirthText = value;
                OnPropertyChanged(nameof(TextBoxDateOfBirthText));
            }
        }
        public string TextBoxNumberPassportText
        {
            get => _textBoxNumberPassportText;
            set
            {
                _textBoxNumberPassportText = value;
                OnPropertyChanged(nameof(TextBoxNumberPassportText));
            }
        }
        public string TextBoxPasswordPhysicalText
        {
            get => _textBoxPasswordPhysicalText;
            set
            {
                LabelErrorReg = "";
                _textBoxPasswordPhysicalText = value;
                OnPropertyChanged(nameof(TextBoxPasswordPhysicalText));
            }
        }
        public string LabelErrorReg
        {
            get => _labelErrorReg;
            set
            {
                _labelErrorReg = value;
                OnPropertyChanged(nameof(LabelErrorReg));
            }
        }
        public string TextBoxNameOrganizationText
        {
            get => _textBoxNameOrganizationText;
            set
            {
                _textBoxNameOrganizationText = value;
                OnPropertyChanged(nameof(TextBoxNameOrganizationText));
            }
        }
        public string TextBoxLegalAdressText
        {
            get => _textBoxLegalAdressText;
            set
            {
                _textBoxLegalAdressText = value;
                OnPropertyChanged(nameof(TextBoxLegalAdressText));
            }
        }
        public string TextBoxITNText
        {
            get => _textBoxITNText;
            set
            {
                _textBoxITNText = value;
                OnPropertyChanged(nameof(TextBoxITNText));
            }
        }
        public string TextBoxStartWorkText
        {
            get => _textBoxStartWorkText;
            set
            {
                LabelErrorReg = "";
                _textBoxStartWorkText = value;
                OnPropertyChanged(nameof(TextBoxStartWorkText));
            }
        }
        public string TextBoxPasswordLegalText
        {
            get => _textBoxPasswordLegalText;
            set
            {
                LabelErrorReg = "";
                _textBoxPasswordLegalText = value;
                OnPropertyChanged(nameof(TextBoxPasswordLegalText));
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
        public void CreateLegalPerson(string TextBoxNameOrganizationText, string TextBoxLegalAdressText, string TextBoxPasswordLegalText, string TextBoxITNText, string TextBoxStartWorkText)
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
                password = TextBoxPasswordLegalText,
                phoneNumber = Convert.ToString(Convert.ToDouble(lastClient.phoneNumber) + 1),
                ITN = TextBoxITNText,
                legalAdress = TextBoxLegalAdressText,
                 nameOrganisation = TextBoxNameOrganizationText,
                startDate = Convert.ToDateTime(TextBoxStartWorkText),
                freeGB = 0,
                freeMin = 0,
                freeSms = 0
            };
            dbOperation.CreateClient(client);
        }

    }
}
