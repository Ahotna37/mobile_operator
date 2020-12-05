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
        
        public WindowBegin()
        {
            InitializeComponent();
            this.Loaded += WindowBegin_Loaded;
            //DataContext = new MainWindowModel();
        }
        private void WindowBegin_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню CodeBehindBegin
            BeginWindowModel begin = new BeginWindowModel();
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
                    AutorisationModel autorisationVM = new AutorisationModel(this);
                    autorisationView.DataContext = autorisationVM;
                    //отображаем
                    this.ContentAutorisationRegistration.Content = autorisationView;
                    break;
                case ViewTypeBegin.Registration:
                    //загружаем вьюшку, ее вьюмодель
                    Registration registrationViev = new Registration();
                    RegistrationModel registrationVM = new RegistrationModel(this);
                    registrationViev.DataContext = registrationVM;
                    //отображаем
                    this.ContentAutorisationRegistration.Content = registrationViev;
                    break;
                case ViewTypeBegin.MainWindow:
                    //загружаем вьюшку, ее вьюмодель
                    MainWindow mainWindow = new MainWindow();
                    //MainWindowModel mainWindowVM = new MainWindowModel();
                    //mainWindow.DataContext = mainWindowVM;
                    //отображаем
                    //mainWindow.ContentPresenterOutput.Content = mainWindow;
                    //this.ContentAutorisationRegistration.Content = autorisationView;
                    this.Close();
                    mainWindow.Show();
                    break;
            }
        }
    }
}
