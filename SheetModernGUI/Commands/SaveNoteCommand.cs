using Sheet.ModernGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.ModernGUI.Commands
{
    public class SaveNoteCommand : ViewModelCommand<NoteViewModel>
    {
        public SaveNoteCommand(NoteViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            NoteViewModel noteVM = parameter as NoteViewModel;
            if (noteVM == null)
                return;
            noteVM.UpdateLabels();
            noteVM.Save();
            noteVM.SelectNote();
        }
    }
}
