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
    public class MainViewModel : ViewModelBase
    {
        private IDictionary<int, LabelViewModel> labelViewModels = new Dictionary<int, LabelViewModel>();
        private IDictionary<int, NoteViewModel> noteViewModels = new Dictionary<int, NoteViewModel>();
        //private IDictionary<int, AttachmentViewModel> attachmentViewModels = new Dictionary<int, AttachmentViewModel>();
        //private IDictionary<int, MetainfoViewModel> metainfoViewModels = new Dictionary<int, MetainfoViewModel>();

        private ObservableCollection<LabelViewModel> labels;
        private ObservableCollection<NoteViewModel> openNotes;

        private NoteViewModel selectedNote;

        private OpenNoteCommand openNote;
        private NewNoteCommand newNote;
        private CloseNoteCommand closeNote;

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

                OpenNotes.CollectionChanged += openNotes_CollectionChanged;
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

        public void LoadLabels()
        {
            foreach (var label in App.Bll.GetLabels())
            {
                var labelViewModel = new LabelViewModel(label, noteViewModels);
                labels.Add(labelViewModel);
                labelViewModels.Add(label.ID, labelViewModel);
            }
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
        }
    }
}