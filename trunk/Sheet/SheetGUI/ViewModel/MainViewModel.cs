using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Sheet.GUI;
using Sheet.Facade.Services;
using System.Collections.Generic;

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
                labels = new ObservableCollection<LabelViewModel>();
            }
        }

        public ObservableCollection<LabelViewModel> Labels
        {
            get { return labels; }
        }

        public void LoadLabels()
        {
            foreach (var label in App.Bll.GetLabels())
            {
                var labelViewModel = new LabelViewModel(label);
                labels.Add(labelViewModel);
                labelViewModels.Add(label.ID, labelViewModel);
            }
        }
    }
}