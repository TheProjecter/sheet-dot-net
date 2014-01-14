using GalaSoft.MvvmLight;
using Sheet.ModernGUI.Commands;
using Sheet.ModernGUI.Model;
using Sheet.ModernGUI.SheetServiceReference;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

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
        private ObservableCollection<NoteViewModel> searchResults;

        private Visibility searchResultsVisibility = Visibility.Collapsed;
        private Visibility openNoteVisibility = Visibility.Collapsed;
        private string searchString;

        private NewNoteCommand newNote;
        private SimpleSearchCommand simpleSearch;
        private HideSearchViewCommand hideSearch;
        private CloseNoteCommand closeNote;

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
            newNote = new NewNoteCommand(this);
            simpleSearch = new SimpleSearchCommand(this);
            hideSearch = new HideSearchViewCommand(this);
            closeNote = new CloseNoteCommand(this);
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

        public ObservableCollection<NoteViewModel> SearchResults
        {
            get
            {
                if (searchResults == null)
                {
                    searchResults = new ObservableCollection<NoteViewModel>();
                }
                return searchResults;
            }
        }

        public ICommand NewNote
        {
            get { return newNote; }
        }
        public ICommand SimpleSearch
        {
            get { return simpleSearch; }
        }
        public ICommand HideSearch
        {
            get { return hideSearch; }
        }
        public ICommand CloseNote
        {
            get { return closeNote; }
        }

        public NoteViewModel SelectedNote
        {
            get { return selectedNote; }
            set
            {
                if (value == selectedNote)
                    return;

                this.selectedNote = value;
                if (value == null)
                {
                    OpenNoteVisibility = Visibility.Collapsed;
                }
                else
                {
                    OpenNoteVisibility = Visibility.Visible;
                }
                base.RaisePropertyChanged("SelectedNote");
            }
        }

        
        public Visibility SearchResultsVisibility
        {
            get { return searchResultsVisibility; }
            set
            {
                if (searchResultsVisibility == value)
                    return;

                searchResultsVisibility = value;

                RaisePropertyChanged("SearchResultsVisibility");
            }
        }

        public Visibility OpenNoteVisibility
        {
            get { return openNoteVisibility; }
            set
            {
                if (openNoteVisibility == value)
                    return;

                openNoteVisibility = value;
                RaisePropertyChanged("OpenNoteVisibility");
            }
        }

        public string SearchString
        {
            get { return searchString; }
            set
            {
                if (searchString == value)
                {
                    return;
                }
                searchString = value;
                RaisePropertyChanged("SearchString");
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
                if (label.Notes.Count > 0)
                {
                    Labels.Add(label); 
                }
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