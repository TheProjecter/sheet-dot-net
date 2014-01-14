using Sheet.ModernGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Sheet.ModernGUI.Commands
{
    public class NewNoteCommand : ViewModelCommand<MainViewModel>
    {
        public NewNoteCommand(MainViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public async override void Execute(object parameter)
        {
            NoteViewModel newNoteVM = vm.GetViewModel(await App.Bll.NewNote());
            newNoteVM.Connect();
            
            vm.SelectedNote = newNoteVM;
            
        }
    }
}
