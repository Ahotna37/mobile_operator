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

        //ctor
        public MainControlModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));
            _MainCodeBehind = codeBehind;


        }
        public int? CountMinutes(int id)
        {
            allClients = dbOperation.GetAllClients();
            ClientModel client = allClients.Where(i => i.id == id).FirstOrDefault();
            return client.freeMin;
        }
        public int? CountSms(int id)
        {
            allClients = dbOperation.GetAllClients();
            ClientModel client = allClients.Where(i => i.id == id).FirstOrDefault();
            return client.freeSms;
        }
        public float? CountGB(int id)
        {
            allClients = dbOperation.GetAllClients();
            ClientModel client = allClients.Where(i => i.id == id).FirstOrDefault();
            return client.freeGB;
        }
    }
}
