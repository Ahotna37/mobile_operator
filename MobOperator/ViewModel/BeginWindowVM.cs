using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MobOperator.View;
using static MobOperator.View.WindowBegin;

namespace MobOperator.ViewModel
{
    public class BeginWindowVM
    {
        public IBeginWindowCodeBehind CodeBehindBegin { get; set; }
        public BeginWindowVM()
        {

        }
        /* private RelayCommand loadBeginWindow;
         private RelayCommand loadAutorisation;
         private RelayCommand loadRegistration;

         public RelayCommand LoadBeginWindow
         {
             get
             {
                 return loadBeginWindow = loadBeginWindow ??
                   new RelayCommand(OutBeginWindow, true);
             }
         }
         private void OutBeginWindow()
         {
             CodeBehindBegin.LoadView(ViewTypeBegin.BeginWindow);
         }

         public RelayCommand LoadAutorisation
         {
             get
             {
                 return loadAutorisation = loadAutorisation ??
                   new RelayCommand(OutAutorisation, true);
             }
         }
         private void OutAutorisation()
         {
             CodeBehindBegin.LoadView(ViewTypeBegin.Autorisation);
         }
         public RelayCommand LoadRegistration
         {
             get
             {
                 return loadRegistration = loadRegistration ??
                   new RelayCommand(OutRegistration, true);
             }
         }
         private void OutRegistration()
         {
             CodeBehindBegin.LoadView(ViewTypeBegin.Registration);
         }
     }*/
    }
}
