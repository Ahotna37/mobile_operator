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
using System.Windows.Shapes;

namespace MobOperator.View
{
    /// <summary>
    /// Логика взаимодействия для WindowBegin.xaml
    /// </summary>
    /// 
    public interface IBeginWindowCodeBehind
    {
        void LoadView(ViewTypeBegin typeViewBegin);
    }

    /// <summary>
    /// Типы вьюшек для загрузки
    /// </summary>
    public enum ViewTypeBegin
    {
        MainWindow,
        Autorisation,
        Registration,
    }
    public partial class WindowBegin : Window, IBeginWindowCodeBehind
    {
        public AutorisationVM autorisationVM;
        public RegistrationVM registrationVM;
        public WindowBegin()
        {
            InitializeComponent();
            this.Loaded += WindowBegin_Loaded;
            //DataContext = new MainWindowModel();
        }
        private void WindowBegin_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню CodeBehindBegin
            BeginWindowVM begin = new BeginWindowVM();
            //даем доступ к этому кодбихайнд
            begin.CodeBehindBegin = this;
            //делаем эту вьюмодел контекстом данных
            this.DataContext = begin;
            //загрузка стартовой View
            LoadView(ViewTypeBegin.Autorisation);
        }
        public void LoadView(ViewTypeBegin typeViewBegin)
        {
            switch (typeViewBegin)
            {
                case ViewTypeBegin.Autorisation:
                    //загружаем вьюшку, ее вьюмодель
                    Autorisation autorisationView = new Autorisation();
                    autorisationVM = new AutorisationVM(this);
                    autorisationView.DataContext = autorisationVM;
                    //отображаем
                    this.ContentAutorisationRegistration.Content = autorisationView;
                    break;
                case ViewTypeBegin.Registration:
                    //загружаем вьюшку, ее вьюмодель
                    Registration registrationViev = new Registration();
                    registrationVM = new RegistrationVM(this);
                    registrationViev.DataContext = registrationVM;
                    //отображаем
                    this.ContentAutorisationRegistration.Content = registrationViev;
                    break;
                case ViewTypeBegin.MainWindow:
                    //загружаем вьюшку, ее вьюмодель
                    MainWindowVM mainWindowVM = null;
                    if (autorisationVM.IdUser != 0)
                    {
                        registrationVM = new RegistrationVM(this);
                        registrationVM.IdUser = 0;
                        mainWindowVM = new MainWindowVM(autorisationVM.IdUser);
                    }
                    if ( registrationVM.IdUser != 0)
                    {
                        mainWindowVM = new MainWindowVM(registrationVM.IdUser);
                    }
                    MainWindow mainWindow = new MainWindow();
                    mainWindowVM.CodeBehind = mainWindow;
                    mainWindow.DataContext = mainWindowVM;

                    //отображаем
                    //mainWindow.ContentPresenterOutput.Content = mainWindow;
                    //this.ContentAutorisationRegistration.Content = autorisationView;
                    this.Close();
                    mainWindow.Show();
                    break;
            }
/*            private void OpenMainWindow()
            {
                MainWindow sellerWin = new MainWindow();
                SellerWindowVM vm = new SellerWindowVM(((dynamic)DataContext).LoginText);
                vm.CodeBehind = sellerWin;
                sellerWin.DataContext = vm;
                sellerWin.Show();
                Close();
            }*/

        }
    }
}
