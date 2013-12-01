using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Sheet.GUI.Commands
{
    public class NewNoteCommand : ViewModelCommand<MainViewModel>
    {
        public NewNoteCommand(MainViewModel vm) : base (vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            NoteViewModel newNoteVM = vm.GetViewModel(App.Bll.NewNote());
            newNoteVM.Connect();
            vm.OpenNotes.Add(newNoteVM);
            vm.SelectedNote = newNoteVM;
        }
    }
}
