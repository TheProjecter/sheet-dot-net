using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Sheet.GUI;
using Sheet.Facade.Services;
using System.Collections.Generic;
using Sheet.GUI.Commands;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;
using System.Linq;
using Sheet.Facade.Notes;

namespace Sheet.GUI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public partial class MainViewModel : ViewModelBase
    {
        private ObservableCollection<LabelViewModel> labels;
        private ObservableCollection<NoteViewModel> openNotes;
        private ObservableCollection<NoteViewModel> searchResults;

        private NoteViewModel selectedNote;

        private OpenNoteCommand openNote;
        private NewNoteCommand newNote;
        private CloseNoteCommand closeNote;
        private DeleteNoteCommand deleteNote;
        private SaveNoteCommand saveNote;
        private DelayedSaveNoteCommand delayedSaveNote;
        private SimpleSearchCommand simpleSearch;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                openNote = new OpenNoteCommand(this);
                newNote = new NewNoteCommand(this);
                closeNote = new CloseNoteCommand(this);
                deleteNote = new DeleteNoteCommand(this);
                saveNote = new SaveNoteCommand(this);
                delayedSaveNote = new DelayedSaveNoteCommand(this);
                simpleSearch = new SimpleSearchCommand(this);

                OpenNotes.CollectionChanged += openNotes_CollectionChanged;
                SearchResults.CollectionChanged += searchResults_CollectionChanged;
            }
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

        public ObservableCollection<NoteViewModel> OpenNotes
        {
            get
            {
                if (openNotes == null)
                {
                    openNotes = new ObservableCollection<NoteViewModel>();
                    //var itemsView = (IEditableCollectionView)CollectionViewSource.GetDefaultView(openNotes);
                    //itemsView.NewItemPlaceholderPosition = NewItemPlaceholderPosition.AtEnd;
                }
                return openNotes;
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

        public void LoadLabels()
        {
            Labels.Clear();
            foreach (var label in App.Bll.GetLabels())
            {
                Labels.Add(this.GetViewModel(label));
            }
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

        public Visibility TabVisibility
        {
            get { return openNotes.Count == 0 ? Visibility.Collapsed : Visibility.Visible; }
        }

        void openNotes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.RaisePropertyChanged("TabVisibility");

            if (openNotes.Contains(selectedNote) == false)
            {
                SelectedNote = OpenNotes.LastOrDefault();
            }
        }

        private Visibility searchResultsVisibility = Visibility.Collapsed;
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

        public Visibility NoResultsVisibility
        {
            get { return searchResults.Count == 0 && searchResultsVisibility == Visibility.Visible ? Visibility.Visible : Visibility.Collapsed; }
        }

        void searchResults_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.RaisePropertyChanged("NoResultsVisibility");
        }

        public ICommand OpenNote
        {
            get { return openNote; }
        }

        public ICommand NewNote
        {
            get { return newNote; }
        }

        public ICommand CloseNote
        {
            get { return closeNote; }
        }

        public ICommand DeleteNote
        {
            get { return deleteNote; }
        }

        public ICommand SaveNote
        {
            get { return saveNote; }
        }

        public ICommand DelayedSaveNote
        {
            get { return delayedSaveNote; }
        }

        public ICommand SimpleSearch
        {
            get { return simpleSearch; }
        }
    }
}