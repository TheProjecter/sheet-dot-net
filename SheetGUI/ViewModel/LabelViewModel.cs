using GalaSoft.MvvmLight;
using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public class LabelViewModel : CompositeViewModel
    {
        private ILabel model;

        private ObservableCollection<NoteViewModel> notes;

        public LabelViewModel(ILabel model, MainViewModel main) : base(main)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            this.model = model;
            main.RegisterViewModel(model, this);
            LoadViewModels();
        }

        protected override void LoadViewModels()
        {
            Notes.Clear();
            foreach (var note in model.Notes)
            {
                Notes.Add(main.GetViewModel(note));
            }
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

        public ObservableCollection<NoteViewModel> Notes
        {
            get 
            {
                if (notes == null)
                    notes = new ObservableCollection<NoteViewModel>();
                return notes;
            }
        }

        public ILabel Model
        {
            set
            {
                if (this.model == value)
                    return;

                this.model = value;
                base.RaisePropertyChanged("");
                LoadViewModels();
            }
        }
    }
}
