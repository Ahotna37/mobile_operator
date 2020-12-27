using MobOperator.View;
using MobOperator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MobOperator
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    /// 
    public interface IMainWindowsCodeBehind
    {
        void LoadView(ViewType typeView);
    }

    /// <summary>
    /// Типы вьюшек для загрузки
    /// </summary>
    public enum ViewType
    {
        Main,
        AddBalance,
        CallAndSms,
        Tariff,
        Service,
        CreateCall,
        CreateSms,
    }
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
        public int idUser;
        public MainWindow( )
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            this.Loaded += MainWindow_Loaded;
            idUser = MainWindowVM.idUserNow;
            //DataContext = new MainWindowModel();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
/*            //загрузка вьюмодел для кнопок меню
            MainWindowModel vm = new MainWindowModel();
            //даем доступ к этому кодбихайнд
            vm.CodeBehind = this;
            //делаем эту вьюмодел контекстом данных
            this.DataContext = vm;*/
            //загрузка стартовой View
            LoadView(ViewType.Main);
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Main:
                    //загружаем вьюшку, ее вьюмодель
                    MainWindowVM mainWindowVM = new MainWindowVM(idUser);
                    MainWindow mainWindow = new MainWindow();
                    mainWindowVM.CodeBehind = mainWindow;
                    mainWindow.DataContext = mainWindowVM;
                    MainControl view = new MainControl();
                    MainControlVM vm = new MainControlVM(idUser);
                    view.DataContext = vm;
                    //отображаем
                    this.ContentPresenterOutput.Content = view;
                    break;
                case ViewType.AddBalance:
                    //загружаем вьюшку, ее вьюмодель
                    AddBalance addBalanceView = new AddBalance();
                    AddBalanceVM AddBalanceVm = new AddBalanceVM(idUser);
                    addBalanceView.DataContext = AddBalanceVm;
                    //отображаем
                    this.ContentPresenterOutput.Content = addBalanceView;
                    break;
                case ViewType.CallAndSms:
                    //загружаем вьюшку, ее вьюмодель
                    CallAndSms callAndSmsView = new CallAndSms();
                    CallAndSmsVM callAndSmsVm = new CallAndSmsVM(idUser,this);
                    callAndSmsView.DataContext = callAndSmsVm;
                    //отображаем
                    this.ContentPresenterOutput.Content = callAndSmsView;
                    break;
                case ViewType.Tariff:
                    //загружаем вьюшку, ее вьюмодель
                    Tariff tariffview = new Tariff();
                    TariffVM tariffVm = new TariffVM(idUser);
                    tariffview.DataContext = tariffVm;
                    //отображаем
                    this.ContentPresenterOutput.Content = tariffview;
                    break;
                case ViewType.Service:
                    //загружаем вьюшку, ее вьюмодель
                    Service serviceView = new Service();
                    ServiceVM serviceVM = new ServiceVM(idUser);
                    serviceView.DataContext = serviceVM;
                    //отображаем
                    this.ContentPresenterOutput.Content = serviceView;
                    break;
                case ViewType.CreateCall:
                    //загружаем вьюшку, ее вьюмодель
                    CreateCall callView = new CreateCall();
                    CreateCallVM callVM = new CreateCallVM(idUser, this);
                    callView.DataContext = callVM;
                    //отображаем
                    this.ContentPresenterOutput.Content = callView;
                    break;
                case ViewType.CreateSms:
                    //загружаем вьюшку, ее вьюмодель
                    CreateSms smsView = new CreateSms();
                    CreateSmsVM smsVM = new CreateSmsVM(idUser, this);
                    smsView.DataContext = smsVM;
                    //отображаем
                    this.ContentPresenterOutput.Content = smsView;
                    break;
                /*case ViewType.CheckListForPdf:
                    //загружаем вьюшку, ее вьюмодель
                    CheckListForPdf CheckListForPdfView = new CheckListForPdf();
                    CheckListForPdfVM checkListForPdfVM = new CheckListForPdfVM(idUser,Convert.ToDateTime("01.01.2000"), Convert.ToDateTime("01.01.2020"));
                    //checkListForPdfVM.CodeBehind = CheckListForPdfView;
                    CheckListForPdfView.DataContext = checkListForPdfVM;
                    CheckListForPdfView.Show();
                    *//*                    //отображаем
                                        this.ContentPresenterOutput.Content = CheckListForPdfView;*//*
                    break;*/
            }


        }
    }
}
