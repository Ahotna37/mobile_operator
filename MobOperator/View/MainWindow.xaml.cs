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
        Service
    }
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            this.Loaded += MainWindow_Loaded;
            //DataContext = new MainWindowModel();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню
            MainWindowModel vm = new MainWindowModel();
            //даем доступ к этому кодбихайнд
            vm.CodeBehind = this;
            //делаем эту вьюмодел контекстом данных
            this.DataContext = vm;
            //загрузка стартовой View
            LoadView(ViewType.Main);
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Main:
                    //загружаем вьюшку, ее вьюмодель
                    MainControl view = new MainControl();
                    MainControlModel vm = new MainControlModel(this);
                    view.DataContext = vm;
                    //отображаем
                    this.ContentPresenterOutput.Content = view;
                    break;
                case ViewType.AddBalance:
                    //загружаем вьюшку, ее вьюмодель
                    AddBalance addBalanceView = new AddBalance();
                    AddBalanceModel AddBalanceVm = new AddBalanceModel(this);
                    addBalanceView.DataContext = AddBalanceVm;
                    //отображаем
                    this.ContentPresenterOutput.Content = addBalanceView;
                    break;
                case ViewType.CallAndSms:
                    //загружаем вьюшку, ее вьюмодель
                    CallAndSms callAndSmsView = new CallAndSms();
                    CallAndSmsModel callAndSmsVm = new CallAndSmsModel(this);
                    callAndSmsView.DataContext = callAndSmsVm;
                    //отображаем
                    this.ContentPresenterOutput.Content = callAndSmsView;
                    break;
                case ViewType.Tariff:
                    //загружаем вьюшку, ее вьюмодель
                    Tariff tariffview = new Tariff();
                    TariffModel tariffVm = new TariffModel(this);
                    tariffview.DataContext = tariffVm;
                    //отображаем
                    this.ContentPresenterOutput.Content = tariffview;
                    break;
                case ViewType.Service:
                    //загружаем вьюшку, ее вьюмодель
                    Service serviceView = new Service();
                    ServiceModel serviceVm = new ServiceModel(this);
                    serviceView.DataContext = serviceVm;
                    //отображаем
                    this.ContentPresenterOutput.Content = serviceView;
                    break;
            }


        }
    }
}
