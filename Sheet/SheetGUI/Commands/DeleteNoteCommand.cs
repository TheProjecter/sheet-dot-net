using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.Commands
{
    public class DeleteNoteCommand : GlobalCommand
    {
        public DeleteNoteCommand(MainViewModel main) : base(main) { }

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
            if (main.OpenNotes.Contains(noteVM))
                main.OpenNotes.Remove(noteVM);
            noteVM.Delete();
            for (int i = 0; i < main.Labels.Count; ++i)
            {
                if (main.Labels[i].Notes.Count == 0)
                {
                    main.Labels.Remove(main.Labels[i]);
                    --i;
                }
            }
        }
    }
}
