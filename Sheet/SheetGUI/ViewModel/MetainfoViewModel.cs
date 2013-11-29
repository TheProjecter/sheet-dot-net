using GalaSoft.MvvmLight;
using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public class MetainfoViewModel : ViewModelBase
    {
        private IMetainfo model;

        public MetainfoViewModel(IMetainfo model)
        {
            this.model = model;
        }

        public IMetainfo Model
        {
            set
            {
                if (this.model == value)
                    return;

                this.model = value;
                base.RaisePropertyChanged("");
            }
        }
    }
}
