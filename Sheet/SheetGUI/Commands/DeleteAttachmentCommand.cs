using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.Commands
{
    public class DeleteAttachmentCommand : ViewModelCommand<NoteViewModel>
    {
        public DeleteAttachmentCommand(NoteViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            AttachmentViewModel attachmentVM = parameter as AttachmentViewModel;
            if (attachmentVM == null)
                return;
            if (vm.Attachments.Contains(attachmentVM))
                vm.Attachments.Remove(attachmentVM);
            attachmentVM.Delete();
        }
    }
}
