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
    public class LabelViewModel : ViewModelBase
    {
        private ILabel model;

        private ObservableCollection<NoteViewModel> notes = new ObservableCollection<NoteViewModel>();

        public LabelViewModel(ILabel model, IDictionary<int, NoteViewModel> noteViewModels)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (noteViewModels == null)
                throw new ArgumentNullException("noteViewModels");
            this.model = model;
            foreach (var note in model.Notes)
            {
                var noteViewModel = new NoteViewModel(note);
                notes.Add(noteViewModel);
                noteViewModels.Add(model.ID, noteViewModel);
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
            get { return notes; }
        }
    }
}
