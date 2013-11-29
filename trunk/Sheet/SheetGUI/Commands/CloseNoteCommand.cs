using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sheet.GUI.Commands
{
    public class CloseNoteCommand : GlobalCommand
    {
        public CloseNoteCommand(MainViewModel main) : base(main) { }

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
            main.SelectedNote = main.OpenNotes.LastOrDefault();
            if (main.OpenNotes.Contains(noteVM))
                main.OpenNotes.Remove(noteVM);
        }
    }
}
