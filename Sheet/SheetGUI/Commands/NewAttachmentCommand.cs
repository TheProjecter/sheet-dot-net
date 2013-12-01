using Microsoft.Win32;
using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

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
            dialog.Filter = "All files (*.*)|*.*";
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
            try
            {
                Stream stream = dialog.OpenFile();
                vm.AddNewAttachment(stream, dialog.SafeFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file: " + ex.Message);
            }
        }
    }
}
