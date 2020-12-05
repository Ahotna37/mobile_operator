﻿using BLL;
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
    class AutorisationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IBeginWindowCodeBehind _BeginCodeBehind;

        private string _textBoxLoginText;
        private string _passwordBoxLogin;

        DbOperation dbOperation = new DbOperation();
        List<ClientModel> allClients;

        private RelayCommand loadMainWindow;
        private RelayCommand loadRegistration;

        //ctor
        public AutorisationModel(IBeginWindowCodeBehind CodeBehindBegin)
        {
            if (CodeBehindBegin == null) throw new ArgumentNullException(nameof(CodeBehindBegin));

            _BeginCodeBehind = CodeBehindBegin;
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
            
            _BeginCodeBehind.LoadView(ViewTypeBegin.MainWindow);
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TextBoxLoginText
        {
            get => _textBoxLoginText;
            set
            {
                _textBoxLoginText = value;
                OnPropertyChanged(nameof(_textBoxLoginText));
            }
        }

        public string PasswordBoxLogin
        {
            get => _passwordBoxLogin;
            set
            {
                _passwordBoxLogin = value;
                OnPropertyChanged(nameof(_passwordBoxLogin));
            }
        }

        public int CheckClient(string _textBoxLoginText, string pass)
        {
            int idClient;
            allClients = dbOperation.GetAllClients();
            ClientModel client = allClients.Where(i => i.phoneNumber == Convert.ToInt32(_textBoxLoginText)).FirstOrDefault();
            if (client.password == pass)
            {
                idClient = client.id;
            }
            else
            {
                //errorMassage();
                return 0;
            }
            return idClient;
        }
    }

}

