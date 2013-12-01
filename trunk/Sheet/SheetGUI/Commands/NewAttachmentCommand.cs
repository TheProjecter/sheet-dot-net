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
    public class NewAttachmentCommand : ViewModelCommand<NoteViewModel>
    {
        private static OpenFileDialog dialog;

        static NewAttachmentCommand()
        {
            dialog = new OpenFileDialog();
            dialog.Title = "Add attachment...";
            dialog.Multiselect = false;
            dialog.CheckPathExists = true;
            dialog.CheckFileExists = true;
        }

        public NewAttachmentCommand(NoteViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            if (dialog.ShowDialog() == false)
                return;
            Stream stream = dialog.OpenFile();
            vm.AddNewAttachment(stream, dialog.SafeFileName);
        }
    }
}
