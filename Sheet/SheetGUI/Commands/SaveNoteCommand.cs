using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.Commands
{
    public class SaveNoteCommand : GlobalCommand
    {
        public SaveNoteCommand(MainViewModel main) : base(main) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            NoteViewModel vm = parameter as NoteViewModel;
            if (vm == null)
                return;
            vm.Save();
        }
    }
}
