using Sheet.Facade.Notes;
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
        public NoteViewModel GetViewModel(INote model)
        {
            NoteViewModel vm;
            if (noteViewModels.ContainsKey(model.ID))
            {
                vm = noteViewModels[model.ID];
                vm.Model = model;
            }
            else
            {
                vm = new NoteViewModel(model, this);
            }
            return vm;
        }

        internal void RegisterViewModel(INote model, NoteViewModel vm)
        {
            noteViewModels.Add(model.ID, vm);
        }

        internal void UnregisterViewModel(INote model)
        {
            noteViewModels.Remove(model.ID);
        }

        public LabelViewModel GetViewModel(ILabel model)
        {
            LabelViewModel vm;
            if (labelViewModels.ContainsKey(model.ID))
            {
                vm = labelViewModels[model.ID];
                vm.Model = model;
            }
            else
            {
                vm = new LabelViewModel(model, this);
            }
            return vm;
        }

        internal void RegisterViewModel(ILabel model, LabelViewModel vm)
        {
            labelViewModels.Add(model.ID, vm);
        }

        internal void UnregisterViewModel(ILabel model)
        {
            labelViewModels.Remove(model.ID);
        }

        public AttachmentViewModel GetViewModel(IAttachment model)
        {
            AttachmentViewModel vm;
            if (attachmentViewModels.ContainsKey(model.ID))
            {
                vm = attachmentViewModels[model.ID];
                vm.Model = model;
            }
            else
            {
                vm = new AttachmentViewModel(model, this);
            }
            return vm;
        }

        internal void RegisterViewModel(IAttachment model, AttachmentViewModel vm)
        {
            attachmentViewModels.Add(model.ID, vm);
        }

        internal void UnregisterViewModel(IAttachment model)
        {
            attachmentViewModels.Remove(model.ID);
        }

        public MetainfoViewModel GetViewModel(IMetainfo model)
        {
            MetainfoViewModel vm;
            if (metainfoViewModels.ContainsKey(model.ID))
            {
                vm = metainfoViewModels[model.ID];
                vm.Model = model;
            }
            else
            {
                vm = new MetainfoViewModel(model, this);
            }
            return vm;
        }

        internal void RegisterViewModel(IMetainfo model, MetainfoViewModel vm)
        {
            metainfoViewModels.Add(model.ID, vm);
        }

        internal void UnregisterViewModel(IMetainfo model)
        {
            metainfoViewModels.Remove(model.ID);
        }
    }
}
