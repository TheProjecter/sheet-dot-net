using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Input;

namespace Sheet.GUI.Commands
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
            if (!vm.OpenNotes.Contains(noteVM))
                vm.OpenNotes.Add(noteVM);

            vm.SelectedNote = noteVM;
        }
    }
}
