using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public abstract class CompositeViewModel : SheetViewModelBase
    {
        public CompositeViewModel(MainViewModel main) : base (main) { }

        protected abstract void LoadViewModels();
    }
}
