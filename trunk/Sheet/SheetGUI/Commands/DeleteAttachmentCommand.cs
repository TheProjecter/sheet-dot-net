using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

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

            if (MessageBox.Show("Are you sure you want to delete this attachemnt? Only the stored copy will be erased, your original file will be preserved.", "Warning", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Warning) == System.Windows.MessageBoxResult.No)
                return;

            if (vm.Attachments.Contains(attachmentVM))
                vm.Attachments.Remove(attachmentVM);
            attachmentVM.Delete();
        }
    }
}
