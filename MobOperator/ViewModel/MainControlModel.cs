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
    class MainControlModel : INotifyPropertyChanged
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

        //ctor
        public MainControlModel(int IdUser)
        {
            /*            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));
                        _MainCodeBehind = codeBehind;*/
            client = dbOperation.GetItemClient(IdUser);
            _labelMinUser =  Convert.ToString( client.freeMin);
            _labelInternetUser = Convert.ToString(client.freeGB);
            _labelSMSPhoneUser = Convert.ToString(client.freeSms);


        }
        public string LabelMinOst
        {
            get => _labelMinUser;
        }
        public string LabelInternetOst
        {
            get => _labelInternetUser;
        }
        public string LabelSMSOst
        {
            get => _labelSMSPhoneUser;
        }
    }
}
