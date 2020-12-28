using BLL;
using BLL.Models;
using Caliburn.Micro;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MobOperator.ViewModel
{

    class CheckListForPdfVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        DbOperation dbOperation = new DbOperation();
        public BindableCollection<CallModel> Call { get; set; }
        public BindableCollection<SMSModel> Sms { get; set; }

        public CheckListForPdfVM(int idUser, DateTime dateStart, DateTime dateEnd)
        {
            /*            ClientModel clientModel = dbOperation.GetItemClient(idUser);
                        TariffPlanModel activeTariff = dbOperation.GetActiveTariff(idUser);*/
            //dbOperation.
            Call = new BindableCollection<CallModel>(dbOperation.GetCallClient(idUser));
            Sms = new BindableCollection<SMSModel>(dbOperation.GetSmsClient(idUser));

        }

    }
}


/*dataTable.Columns.Add("Дата");
dataTable.Columns.Add("Время");
dataTable.Columns.Add("Собеседник");
dataTable.Columns.Add("Дистанция");
dataTable.Columns.Add("Цена");
dataTable.Columns.Add("Тип звонка");
//Add rows to the DataTable.
foreach (CallModel call in Call)
{
    dataTable.Rows.Add(new object[] { call.dateCallShort, call.timeTalk, call.numberWasCall, call.callTypeString, call.costCall, call.incomingCallText });
}*/