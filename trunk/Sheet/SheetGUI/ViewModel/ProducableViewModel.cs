using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.GUI.ViewModel
{
    public class ProducableViewModel : ViewModelBase
    {
        protected ViewModelFactory factory;

        public ProducableViewModel(ViewModelFactory factory)
        {
            this.factory = factory;
        }
    }
}
