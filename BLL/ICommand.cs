using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BLL
{
    public interface ICommand
    {
/*        event EventHandler CanExecuteChanged;*/
        void OpenPage(object parameter, Window win);
/*        bool CanExecutive(object parameter);*/
    }
}
