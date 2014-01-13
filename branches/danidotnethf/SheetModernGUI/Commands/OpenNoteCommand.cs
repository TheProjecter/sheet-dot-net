using Sheet.ModernGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Sheet.ModernGUI.Commands
{
    class OpenNoteCommand : ViewModelCommand<MainViewModel>
    {

        public OpenNoteCommand(MainViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            NoteViewModel noteVM = parameter as NoteViewModel;
            if (noteVM == null)
                return;
            //if (!vm.OpenNotes.Contains(noteVM))
            //    vm.OpenNotes.Add(noteVM);
            vm.SelectedNote = noteVM;
            //vm.SetComplexSearchVisible(false);
            noteVM.Load();
        }
    }
}
