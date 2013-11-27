using GalaSoft.MvvmLight;
using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public class LabelViewModel : ViewModelBase
    {
        private ILabel model;

        public LabelViewModel(ILabel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            this.model = model;
        }

        public string Text
        {
            get
            {
                return model.Text;
            }
            set
            {
                if (value == model.Text)
                    return;

                this.model.Text = value;

                base.RaisePropertyChanged("Text");
            }
        }
    }
}
