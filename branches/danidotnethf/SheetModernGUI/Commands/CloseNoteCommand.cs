using Sheet.ModernGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace Sheet.ModernGUI.Commands
{
    public class CloseNoteCommand : ViewModelCommand<MainViewModel>
    {
        public CloseNoteCommand(MainViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            NoteViewModel noteVM = parameter as NoteViewModel;
            if (noteVM == null)
                return;
            vm.SelectedNote = null;
        }
    }
}
