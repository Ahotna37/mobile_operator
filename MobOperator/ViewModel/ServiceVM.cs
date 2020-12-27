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
    class ServiceVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind CodeBehind;
        DbOperation dbOperation = new DbOperation();

        private string _labelCostService;
        private string _labelDescriptionService;

        private ExtraServiceModel _listViewServiceSelected;
        private ExtraServiceModel _listViewServiceConnectedSelected;

        private bool _addServiceButtonsEnabled;
        private bool _deleteServiceButtonsEnabled;
        public BindableCollection<ExtraServiceModel> extraServices { get; set; }
        public BindableCollection<ExtraServiceModel> extraServicesConnected { get; set; }
        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;
        private RelayCommand loadAddService;
        private RelayCommand loadDeleteService;
        int idUser;
        //ctor
        public ServiceVM(int idUsers)
        {
            idUser = idUsers;
            extraServices = new BindableCollection<ExtraServiceModel>(dbOperation.GetAllExtraServices());
            extraServicesConnected = new BindableCollection<ExtraServiceModel>(dbOperation.GetAllServicesConnectedForClient(idUser));
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void LoadAddServiceInDb()
        {
            ExtraServiceModel extraService = ListViewServiceSelected;
            ExtraServiceModel extraServiceConnected = dbOperation.GetAllServicesConnectedForClient(idUser).Where(i => i.name == extraService.name).FirstOrDefault();
            if (extraServiceConnected == null) {
                dbOperation.UpdateBalanceClient(idUser, -extraService.subscFee);
                dbOperation.AddConnectExtraService(idUser, extraService.id);
            }
        }

        public RelayCommand LoadAddService
        {
            get
            {
                return loadAddService = loadAddService ??
                  new RelayCommand(LoadAddServiceInDb, true);
            }
        }
        private void LoadDeleteServiceInDb()
        {
            /*            TariffPlanModel newTariff = ListViewTariffSelected;
                        dbOperation.UpdateBalanceClient(idUser, -newTariff.costChangeTar);
                        dbOperation.UpdateConnectTariff(idUser, newTariff.id);*/
            ExtraServiceModel extraService = ListViewServiceConnectedSelected;
            dbOperation.DeleteConnectedExtraService(idUser, extraService.id);
        }

        public RelayCommand LoadDeleteService
        {
            get
            {
                return loadDeleteService = loadDeleteService ??
                  new RelayCommand(LoadDeleteServiceInDb, true);
            }
        }
        public ExtraServiceModel ListViewServiceSelected
        {
            get => _listViewServiceSelected;
            set
            {
                _listViewServiceSelected = value;
                ChengeAllInWindow(value);
                DeleteServiceButtonsEnabled = false;
                AddServiceButtonsEnabled = true;
                //ListViewServiceConnectedSelected = null;
                OnPropertyChanged(nameof(ListViewServiceSelected));
            }
        }
        public ExtraServiceModel ListViewServiceConnectedSelected
        {
            get => _listViewServiceConnectedSelected;
            set
            {
                _listViewServiceConnectedSelected = value;
                DeleteServiceButtonsEnabled = true;
                AddServiceButtonsEnabled = false;
                //ListViewServiceSelected = null;
                ChengeAllInWindow(value);
                OnPropertyChanged(nameof(ListViewServiceConnectedSelected));
            }
        }
        private void ChengeAllInWindow(ExtraServiceModel service)
        {
            LabelCostService ="Стоимость: "+ Convert.ToString( service.subscFee);
            LabelDescriptionService = "Описание: "+ service.description;
        }
        public string LabelCostService
        {
            get => _labelCostService;
            set
            {
                _labelCostService = value;
                OnPropertyChanged(nameof(LabelCostService));
            }
        }
        public string LabelDescriptionService
        {
            get => _labelDescriptionService;
            set
            {
                _labelDescriptionService = value;
                OnPropertyChanged(nameof(LabelDescriptionService));
            }
        }
/*        public ExtraServiceModel ServiceSelectedButtonsEnabled
        {
            get => _serviceSelectedButtonsEnabled;
            set
            {
                //ListViewServiceConnectedSelected = value;
                ChengeAllInWindow(value);
                TariffPlanModel ActiveTariff = dbOperation.GetActiveTariff(idUser);
                if (ListViewTariffSelected.name.Trim() == ActiveTariff.name.Trim())
                {
                    TariffChangeButtonsEnabled = false;
                }
                OnPropertyChanged(nameof(AddServiceButtonsEnabled));
            }
        }*/

        public bool AddServiceButtonsEnabled
        {
            get => _addServiceButtonsEnabled;
            set
            {
                _addServiceButtonsEnabled = value;
                OnPropertyChanged(nameof(AddServiceButtonsEnabled));
            }
        }

        public bool DeleteServiceButtonsEnabled
        {
            get => _deleteServiceButtonsEnabled;
            set
            {
                _deleteServiceButtonsEnabled = value;
                OnPropertyChanged(nameof(DeleteServiceButtonsEnabled));
            }
        }
    }
}
