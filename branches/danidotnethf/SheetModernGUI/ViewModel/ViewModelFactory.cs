using Sheet.ModernGUI.SheetServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.ModernGUI.ViewModel
{
    public partial class MainViewModel
    {
        private IDictionary<int, LabelViewModel> labelViewModels = new Dictionary<int, LabelViewModel>();
        private IDictionary<int, NoteViewModel> noteViewModels = new Dictionary<int, NoteViewModel>();
        //private IDictionary<int, AttachmentViewModel> attachmentViewModels = new Dictionary<int, AttachmentViewModel>();
        //private IDictionary<int, MetainfoViewModel> metainfoViewModels = new Dictionary<int, MetainfoViewModel>();

        //TODO: add methods to create viewmodels for models, storing the id to retrieve any existing viewmodel if already created.
        public NoteViewModel GetViewModel(Note model)
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

        internal void RegisterViewModel(Note model, NoteViewModel vm)
        {
            if (noteViewModels.ContainsKey(model.ID) == false)
                noteViewModels.Add(model.ID, vm);
        }

        internal void UnregisterViewModel(Note model)
        {
            if (noteViewModels.ContainsKey(model.ID))
                noteViewModels.Remove(model.ID);
        }

        public LabelViewModel GetViewModel(Label model)
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

        internal void RegisterViewModel(Label model, LabelViewModel vm)
        {
            if (labelViewModels.ContainsKey(model.ID) == false)
                labelViewModels.Add(model.ID, vm);
        }

        internal void UnregisterViewModel(Label model)
        {
            if (labelViewModels.ContainsKey(model.ID))
                labelViewModels.Remove(model.ID);
        }

        //public AttachmentViewModel GetViewModel(IAttachment model)
        //{
        //    AttachmentViewModel vm;
        //    if (attachmentViewModels.ContainsKey(model.ID))
        //    {
        //        vm = attachmentViewModels[model.ID];
        //        vm.Model = model;
        //    }
        //    else
        //    {
        //        vm = new AttachmentViewModel(model, this);
        //    }
        //    return vm;
        //}

        //internal void RegisterViewModel(IAttachment model, AttachmentViewModel vm)
        //{
        //    if (attachmentViewModels.ContainsKey(model.ID) == false)
        //        attachmentViewModels.Add(model.ID, vm);
        //}

        //internal void UnregisterViewModel(IAttachment model)
        //{
        //    if (attachmentViewModels.ContainsKey(model.ID))
        //        attachmentViewModels.Remove(model.ID);
        //}

        //public MetainfoViewModel GetViewModel(IMetainfo model)
        //{
        //    MetainfoViewModel vm;
        //    if (metainfoViewModels.ContainsKey(model.ID))
        //    {
        //        vm = metainfoViewModels[model.ID];
        //        vm.Model = model;
        //    }
        //    else
        //    {
        //        vm = new MetainfoViewModel(model, this);
        //    }
        //    return vm;
        //}

        //internal void RegisterViewModel(IMetainfo model, MetainfoViewModel vm)
        //{
        //    if (metainfoViewModels.ContainsKey(model.ID) == false)
        //        metainfoViewModels.Add(model.ID, vm);
        //}

        //internal void UnregisterViewModel(IMetainfo model)
        //{
        //    if (metainfoViewModels.ContainsKey(model.ID))
        //        metainfoViewModels.Remove(model.ID);
        //}
    }
}
