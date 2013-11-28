using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sheet.GUI.Commands
{
    class OpenNoteCommand : ICommand
    {
        private MainViewModel main;

        public OpenNoteCommand(MainViewModel main)
        {
            this.main = main;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            NoteViewModel noteVM = parameter as NoteViewModel;
            if (noteVM == null)
                return;
            if (!main.OpenNotes.Contains(noteVM))
                main.OpenNotes.Add(noteVM);

            main.SelectedNote = noteVM;
        }
    }
}
