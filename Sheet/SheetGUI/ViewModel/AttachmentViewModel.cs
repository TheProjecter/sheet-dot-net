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
        private Attachment model;

        public AttachmentViewModel(Attachment model)
        {
            this.model = model;
        }
    }
}
