using GalaSoft.MvvmLight;
using Sheet.ModernGUI.Commands;
using Sheet.ModernGUI.Model;
using Sheet.ModernGUI.SheetServiceReference;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sheet.ModernGUI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public partial class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private NoteViewModel selectedNote;

        private ObservableCollection<LabelViewModel> labels;
        private ObservableCollection<NoteViewModel> notes;

        private SaveNoteCommand saveNote;

        private LabelViewModel noLabel;

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(() => WelcomeTitle);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// //param: IDataService dataService
        public MainViewModel()
        {
            noLabel = new LabelViewModel(new Label() { 
                                                         Text = "No label",
                                                         ID = -1,
                                                         Notes = new ObservableCollection<Note>()
                                                     }, this);
            //notes = 

            //_dataService = dataService;
            //_dataService.GetData(
            //    (item, error) =>
            //    {
            //        if (error != null)
            //        {
            //            // Report error here
            //            return;
            //        }

            //        WelcomeTitle = item.Title;
            //    });
        }

        public ObservableCollection<LabelViewModel> Labels
        {
            get
            {
                if (labels == null)
                {
                    labels = new ObservableCollection<LabelViewModel>();
                }
                return labels;
            }
        }

        public ObservableCollection<NoteViewModel> Notes
        {
            get
            {
                if (notes == null)
                {
                    notes = new ObservableCollection<NoteViewModel>();
                }
                return notes;
            }
        }
        public ICommand SaveNote
        {
            get { return saveNote; }
        }
        public NoteViewModel SelectedNote
        {
            get { return selectedNote; }
            set
            {
                if (value == selectedNote)
                    return;

                this.selectedNote = value;

                base.RaisePropertyChanged("SelectedNote");
            }
        }

        public async Task LoadLabels()
        {
            ICollection<Note> notes = await App.Bll.GetNotes();
            foreach (var note in notes)
            {
                this.GetViewModel(note).Connect();
            }
            Labels.Clear();
            foreach (var label in labelViewModels.Values)
            {
                Labels.Add(label);
            }
        }


        internal LabelViewModel NoLabel
        {
            get { return noLabel; }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}