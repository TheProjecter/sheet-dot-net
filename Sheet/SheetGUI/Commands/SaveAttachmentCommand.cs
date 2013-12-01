using Microsoft.Win32;
using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.Commands
{
    public class SaveAttachmentCommand : ViewModelCommand<AttachmentViewModel>
    {
        private static SaveFileDialog dialog;

        static SaveAttachmentCommand()
        {
            dialog = new SaveFileDialog();
            dialog.Title = "Save attachment as...";
            dialog.OverwritePrompt = true;
        }

        public SaveAttachmentCommand(AttachmentViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            dialog.FileName = Path.Combine(dialog.InitialDirectory, vm.Name);
            if (dialog.ShowDialog() == false)
                return;
            vm.Save(dialog.FileName);
        }
    }
}
