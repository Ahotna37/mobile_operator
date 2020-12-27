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
using static MobOperator.View.WindowBegin;

namespace MobOperator.ViewModel
{
    public class AutorisationVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        //Fields
        private IBeginWindowCodeBehind _BeginCodeBehind;

        private string _textBoxLoginText ;
        private string _textBoxPasswordText;
        private string _labelErrorLog;
        private int idUser = 0;


        DbOperation dbOperation = new DbOperation();
        List<ClientModel> allClients;

        private RelayCommand loadMainWindow;
        private RelayCommand loadRegistration;

        //ctor
        public AutorisationVM(IBeginWindowCodeBehind CodeBehindBegin)
        {
            if (CodeBehindBegin == null) throw new ArgumentNullException(nameof(CodeBehindBegin));

            _BeginCodeBehind = CodeBehindBegin;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            IdUser = CheckClient(TextBoxLoginText, TextBoxPasswordText);
            if (TextBoxLoginText != "" && TextBoxPasswordText !=null ) {
                if (IdUser != 0)
                {
                    _BeginCodeBehind.LoadView(ViewTypeBegin.MainWindow);
                }
                else
                {
                    LabelErrorLog = "Неверно набраны логин или пароль";
                }
            }
            else
            {
                LabelErrorLog = "Незаполнены поля!";
            }
        }

       /* public RelayCommand LoadAutorisation
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
        }*/
        public RelayCommand LoadRegistration
        {
            get
            {
                return loadRegistration = loadRegistration ??
                  new RelayCommand(OutRegistration, true);
            }
        }
        private void OutRegistration()
        {
            _BeginCodeBehind.LoadView(ViewTypeBegin.Registration);
        }


        public string TextBoxLoginText
        {
            get => _textBoxLoginText;
            set
            {
                LabelErrorLog = "";
                _textBoxLoginText = value;
                OnPropertyChanged(nameof(TextBoxLoginText));
            }
        }
        public string LabelErrorLog
        {
            get => _labelErrorLog;
            set
            {
                _labelErrorLog = value;
                OnPropertyChanged(nameof(LabelErrorLog));
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

        public string TextBoxPasswordText
        {
            get => _textBoxPasswordText;
            set
            {
                LabelErrorLog = "";
                _textBoxPasswordText = value;
                OnPropertyChanged(nameof(TextBoxPasswordText));
            }
        }

        public int CheckClient(string TextBoxLoginText, string TextBoxPasswordText)
        {
            allClients = dbOperation.GetAllClients();
            ClientModel client = allClients.Where(i => i.phoneNumber == TextBoxLoginText).FirstOrDefault();
            if (client != null)
            {
                if (client.password.Trim() == TextBoxPasswordText.Trim())
                {
                    return client.id;
                }
                else
                {
                    //errorMassage();
                    return 0;
                }
            }
            return 0;
        }
    }

}

