using BLL;
using BLL.Models;
using Caliburn.Micro;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Pdf.Grid;
using System.Data;

namespace MobOperator.ViewModel
{
    class CallAndSmsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        //private IMainWindowsCodeBehind _MainCodeBehind;
        DbOperation dbOperation = new DbOperation();
        private IMainWindowsCodeBehind CodeBehind;
        private RelayCommand loadCreateCall;
        private RelayCommand loadCreateSms;
        private RelayCommand loadCheckListForPdf;
        DateTime dateForList;
        public string _comboBoxDateCheckListSelected;
        public BindableCollection<CallModel> Call { get; set; }
        public BindableCollection<SMSModel> Sms { get; set; }
        public BindableCollection<ConnectTariffModel> Tariff { get; set; }
        public BindableCollection<ConnectServiceModel> ExtraService { get; set; }
        public BindableCollection<AddBalanceModel> AddBalance { get; set; }
        int idClient;
        //ctor
        public CallAndSmsVM(int idUser, IMainWindowsCodeBehind codeBehind)
        {
            CodeBehind = codeBehind;
            /*            ClientModel clientModel = dbOperation.GetItemClient(idUser);
                        TariffPlanModel activeTariff = dbOperation.GetActiveTariff(idUser);*/
            //dbOperation.
            idClient = idUser;
            Call = new BindableCollection<CallModel>(dbOperation.GetCallClient(idClient));
            Sms = new BindableCollection<SMSModel>(dbOperation.GetSmsClient(idClient));

        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public RelayCommand LoadCreateCall
        {
            get
            {

                return loadCreateCall = loadCreateCall ??
                  new RelayCommand(OutBeginCreateCall, true);
            }
        }
        private void OutBeginCreateCall()
        {
            CodeBehind.LoadView(ViewType.CreateCall);
        }
        public RelayCommand LoadCreateSms
        {
            get
            {

                return loadCreateSms = loadCreateSms ??
                  new RelayCommand(OutBeginCreateSms, true);
            }
        }
        private void OutBeginCreateSms()
        {
            CodeBehind.LoadView(ViewType.CreateSms);
        }
        private void OutMainWindow()
        {
            OutCheckListForPdf(idClient);
            CodeBehind.LoadView(ViewType.Main);
        }
        public RelayCommand LoadCheckListForPdf
        {
            get
            {

                return loadCheckListForPdf = loadCheckListForPdf ??
                  new RelayCommand(OutMainWindow, true);
            }
        }
        public string ComboBoxDateCheckListSelected
        {
            get => _comboBoxDateCheckListSelected;
            set
            {
                _comboBoxDateCheckListSelected = value;
                OnPropertyChanged(nameof(ComboBoxDateCheckListSelected));
            }
        }
        private void OutCheckListForPdf(int idClient)
        {

            dateForList = DateTime.Now;
            switch (ComboBoxDateCheckListSelected)
            {
                case "Неделя":
                    dateForList = DateTime.Now.AddDays(-7);
                    break;
                case "Месяц":
                    dateForList = DateTime.Now.AddMonths(-1);
                    break;
                case "Год":
                    dateForList = DateTime.Now.AddYears(-1);
                    break;
                case "Все время":
                    dateForList = new DateTime(1000, 1, 1);
                    break;
            }

            Call = new BindableCollection<CallModel>(dbOperation.GetCallClientForDate(idClient, dateForList));
            Sms = new BindableCollection<SMSModel>(dbOperation.GetSmsClientForDate(idClient, dateForList));
            Tariff = new BindableCollection<ConnectTariffModel>(dbOperation.GetConnectTariffClientForDate(idClient, dateForList));
            ExtraService = new BindableCollection<ConnectServiceModel>(dbOperation.GetConnectServiceClientForDate(idClient, dateForList));
            AddBalance = new BindableCollection<AddBalanceModel>(dbOperation.GetAddBalanceClientForDate(idClient, dateForList));

            using (PdfDocument document = new PdfDocument())
            {
                PdfDocument doc = new PdfDocument( );
                PdfPage page = doc.Pages.Add();
                PdfGrid pdfGrid = new PdfGrid();
                DataTable dataTable = new DataTable();
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
                graphics.DrawString("Statement for call", font, PdfBrushes.Black, new PointF(200, 0));
                dataTable.Columns.Add("Date call");
                dataTable.Columns.Add("Time talk");
                dataTable.Columns.Add("Interlocutor");
                dataTable.Columns.Add("Cost");
                foreach (CallModel call in Call)
                {
                    dataTable.Rows.Add(new object[] { call.dateCallShort, call.timeTalk, call.numberWasCall,  call.costCall });
                }
                pdfGrid.DataSource = dataTable;
                pdfGrid.Draw(page, new PointF(10, 30));

                PdfPage page1 = doc.Pages.Add();
                PdfGrid pdfGrid1 = new PdfGrid();
                DataTable dataTable1 = new DataTable();

                PdfGraphics graphics1 = page1.Graphics;
                PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
                graphics1.DrawString("Statement for sms", font1, PdfBrushes.Black, new PointF(200, 0));
                dataTable1.Columns.Add("Date sms");
                dataTable1.Columns.Add("Interlocutor");
                dataTable1.Columns.Add("Cost");
                foreach (SMSModel sms in Sms)
                {
                    dataTable1.Rows.Add(new object[] { sms.dateSmsShort, sms.recipientSms, sms.costSMS });
                }
                pdfGrid1.DataSource = dataTable1;
                pdfGrid1.Draw(page1, new PointF(10, 30));

                PdfPage page2 = doc.Pages.Add();
                PdfGrid pdfGrid2 = new PdfGrid();
                DataTable dataTable2 = new DataTable();
                PdfGraphics graphics2 = page2.Graphics;
                PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
                graphics2.DrawString("Statement for connect tariff plan", font2, PdfBrushes.Black, new PointF(150, 0));
                dataTable2.Columns.Add("Name Tariff");
                dataTable2.Columns.Add("Date connect");
                dataTable2.Columns.Add("Number of months");
                dataTable2.Columns.Add("Cost");
                foreach (ConnectTariffModel tar in Tariff)
                {
                    dataTable2.Rows.Add(new object[] { tar.name, tar.dateConnectTariffBegin, tar.connectedMonth, tar.cost });
                }
                pdfGrid2.DataSource = dataTable2;
                pdfGrid2.Draw(page2, new PointF(10, 30));

                PdfPage page4 = doc.Pages.Add();
                PdfGrid pdfGrid4 = new PdfGrid();
                DataTable dataTable4 = new DataTable();
                PdfGraphics graphics4 = page4.Graphics;
                PdfFont font4 = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
                graphics4.DrawString("Statement for connect extra service", font4, PdfBrushes.Black, new PointF(150, 0));
                dataTable4.Columns.Add("Name extra service");
                dataTable4.Columns.Add("Date connect");
                dataTable4.Columns.Add("Number of months");
                dataTable4.Columns.Add("Cost");
                foreach (ConnectServiceModel serv in ExtraService)
                {
                    dataTable4.Rows.Add(new object[] { serv.name, serv.dateConnectServiceBegin, serv.connectedMonth, serv.cost });
                }
                pdfGrid4.DataSource = dataTable4;
                pdfGrid4.Draw(page4, new PointF(10, 30));

                PdfPage page3 = doc.Pages.Add();
                PdfGrid pdfGrid3 = new PdfGrid();
                DataTable dataTable3 = new DataTable();
                PdfGraphics graphics3 = page3.Graphics;
                PdfFont font3 = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
                graphics3.DrawString("Statement for add balance", font3, PdfBrushes.Black, new PointF(160, 0));
                dataTable3.Columns.Add("Number of card");
                dataTable3.Columns.Add("Date adding");
                dataTable3.Columns.Add("Cost");
                foreach (AddBalanceModel add in AddBalance)
                {
                    dataTable3.Rows.Add(new object[] { add.numberBankCard, add.dateAddBalance, add.SumForAdd });
                }
                pdfGrid3.DataSource = dataTable3;
                pdfGrid3.Draw(page3, new PointF(10, 30));
                doc.Save("Output.pdf");
                doc.Close(true);
            }




            /*using (PdfDocument document = new PdfDocument())
            {
                //Create a new PDF document.
                //MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("Output.pdf"));
                dateForList = DateTime.Now;
                switch (ComboBoxDateCheckListSelected)
                {
                    case "Неделя":
                        dateForList = DateTime.Now.AddDays(-7);
                        break;
                    case "Месяц":
                        dateForList = DateTime.Now.AddMonths(-1);
                        break;
                    case "Год":
                        dateForList = DateTime.Now.AddYears(-1);
                        break;
                    case "Все время":
                        dateForList = new DateTime(1000, 1, 1);
                        break;
                }

                Call = new BindableCollection<CallModel>(dbOperation.GetCallClientForDate(idClient, dateForList));
                Sms = new BindableCollection<SMSModel>(dbOperation.GetSmsClientForDate(idClient, dateForList));
                Tariff = new BindableCollection<ConnectTariffModel>(dbOperation.GetConnectTariffClientForDate(idClient, dateForList));
                ExtraService = new BindableCollection<ConnectServiceModel>(dbOperation.GetConnectServiceClientForDate(idClient, dateForList));
                AddBalance = new BindableCollection<AddBalanceModel>(dbOperation.GetAddBalanceClientForDate(idClient, dateForList));

                PdfDocument doc = new PdfDocument();
                //Add a page.
                PdfPage page = doc.Pages.Add();
                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();
                //Create a DataTable.
                //Звонки
                DataTable dataTableCalls = new DataTable();
                pdfGrid.DataSource = dataTableCalls;
                //Add columns to the DataTable
                dataTableCalls.Columns.Add("Дата");
                dataTableCalls.Columns.Add("Время");
                dataTableCalls.Columns.Add("Собеседник");
                dataTableCalls.Columns.Add("Дистанция");
                dataTableCalls.Columns.Add("Цена");
                dataTableCalls.Columns.Add("Тип звонка");
                //Add rows to the DataTable.
                dataTableCalls.Rows.Add(new object[] { "1", "1", "1", "1", "1", "1" });
*//*                foreach (CallModel call in Call)
                {
                    dataTableCalls.Rows.Add(new object[] {Convert.ToString(call.dateCallShort),
                        Convert.ToString(call.timeTalk),
                        Convert.ToString(call.numberWasCall),
                        Convert.ToString(call.callTypeString),
                        Convert.ToString(call.costCall), 
                        Convert.ToString(call.incomingCallText) });
                }*/
            /*//Assign data source.
            DataTable dataTableSms = new DataTable();
            //Add columns to the DataTable
            pdfGrid.DataSource = dataTableSms;
            dataTableSms.Columns.Add("Дата");
            dataTableSms.Columns.Add("Собеседник");
            dataTableSms.Columns.Add("Тип СМС");
            dataTableSms.Columns.Add("Стоимость");
            //Add rows to the DataTable.
            foreach (SMSModel sms in Sms)
            {
                dataTableSms.Rows.Add(new object[] { sms.dateSmsShort, sms.recipientSms, sms.incomingSmsText, sms.costSMS });

            }
            DataTable dataTableTariff = new DataTable();
            pdfGrid.DataSource = dataTableTariff;
            //Add columns to the DataTable
            dataTableTariff.Columns.Add("Название тарифа");
            dataTableTariff.Columns.Add("Дата подключения");
            dataTableTariff.Columns.Add("Сколько подключен");
            dataTableTariff.Columns.Add("Стоимость");
            //Add rows to the DataTable.
            foreach (ConnectTariffModel tar in Tariff)
            {
                dataTableTariff.Rows.Add(new object[] { tar.name, tar.dateConnectTariffBegin , tar.connectedMonth, tar.cost});
            }
            DataTable dataTableService = new DataTable();
            pdfGrid.DataSource = dataTableService;
            //Add columns to the DataTable
            dataTableService.Columns.Add("Название услуги");
            dataTableService.Columns.Add("Дата подключения");
            dataTableService.Columns.Add("Сколько подключена");
            dataTableService.Columns.Add("Стоимость");
            //Add rows to the DataTable.
            foreach (ConnectServiceModel serv in ExtraService)
            {
                dataTableService.Rows.Add(new object[] { serv.name, serv.dateConnectServiceBegin, serv.connectedMonth, serv.cost });
            }
            DataTable dataTableAddBalance = new DataTable();
            pdfGrid.DataSource = dataTableAddBalance;
            //Add columns to the DataTable
            dataTableAddBalance.Columns.Add("Номер карты");
            dataTableAddBalance.Columns.Add("Имя владельца");
            dataTableAddBalance.Columns.Add("Дата пополнения");
            dataTableAddBalance.Columns.Add("Сумма");
            //Add rows to the DataTable.
            foreach (AddBalanceModel add in AddBalance)
            {
                dataTableAddBalance.Rows.Add(new object[] { add.numberBankCard, add.nameBankCard, add.dateAddBalance, add.SumForAdd });
            }*//*
            //Assign data source.
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new PointF(10, 10));
            //Save the document.
            doc.Save("Output.pdf");
            //close the document
            doc.Close(true);
        }
    }*/
        }
    }
}
