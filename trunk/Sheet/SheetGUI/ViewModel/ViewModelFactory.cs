using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public class ViewModelFactory
    {
        private IDictionary<int, LabelViewModel> labelViewModels = new Dictionary<int, LabelViewModel>();
        private IDictionary<int, NoteViewModel> noteViewModels = new Dictionary<int, NoteViewModel>();
        private IDictionary<int, AttachmentViewModel> attachmentViewModels = new Dictionary<int, AttachmentViewModel>();
        private IDictionary<int, MetainfoViewModel> metainfoViewModels = new Dictionary<int, MetainfoViewModel>();

        //TODO: add methods to create viewmodels for models, storing the id to retrieve any existing viewmodel if already created.
    }
}
