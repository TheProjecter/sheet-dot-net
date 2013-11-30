using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public abstract class CompositeViewModel : ProducableViewModel
    {
        public CompositeViewModel(ViewModelFactory factory) : base (factory) { }

        protected abstract void LoadViewModels();
    }
}
