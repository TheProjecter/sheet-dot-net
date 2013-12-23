using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public class SheetViewModelBase : ViewModelBase
    {
        protected MainViewModel main;

        public SheetViewModelBase(MainViewModel main)
        {
            this.main = main;
        }
    }
}
