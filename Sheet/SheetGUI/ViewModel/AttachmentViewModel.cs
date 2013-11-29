using GalaSoft.MvvmLight;
using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public class AttachmentViewModel : ViewModelBase
    {
        private IAttachment model;

        public AttachmentViewModel(IAttachment model)
        {
            this.model = model;
        }

        public IAttachment Model
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
