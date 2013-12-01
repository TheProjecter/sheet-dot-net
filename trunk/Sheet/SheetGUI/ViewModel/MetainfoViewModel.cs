using GalaSoft.MvvmLight;
using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public class MetainfoViewModel : SheetViewModelBase
    {
        private IMetainfo model;

        public MetainfoViewModel(IMetainfo model, MainViewModel main) : base(main)
        {
            this.model = model;
            main.RegisterViewModel(model, this);
        }

        public string Key
        {
            get
            {
                return model.Key;
            }
            set
            {
                if (value == model.Key)
                    return;

                this.model.Key = value;

                base.RaisePropertyChanged("Key");
            }
        }

        public string Value
        {
            get
            {
                return model.Value;
            }
            set
            {
                if (value == model.Value)
                    return;

                this.model.Value = value;

                base.RaisePropertyChanged("Value");
            }
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
