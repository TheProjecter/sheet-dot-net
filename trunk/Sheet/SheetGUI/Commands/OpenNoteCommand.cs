using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Input;

namespace Sheet.GUI.Commands
{
    class OpenNoteCommand : GlobalCommand
    {

        public OpenNoteCommand(MainViewModel main) : base(main) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public override void Execute(object parameter)
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
