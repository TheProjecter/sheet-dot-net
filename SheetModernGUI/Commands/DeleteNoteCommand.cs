using Sheet.ModernGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.ModernGUI.Commands
{
    public class DeleteNoteCommand : ViewModelCommand<NoteViewModel>
    {
        public DeleteNoteCommand(NoteViewModel vm) : base(vm) 
        {
            vm.PropertyChanged += vm_PropertyChanged;
        }

        void vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedNote" || e.PropertyName == "ComplexSearchViewVisibility" || e.PropertyName == string.Empty)
            {
                base.RaiseCanExecutedChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            NoteViewModel noteVM = parameter as NoteViewModel;
            return noteVM != null;
            //return vm.SelectedNote != null && vm.ComplexSearchViewVisibility != System.Windows.Visibility.Visible;
        }

        public override void Execute(object parameter)
        {
            NoteViewModel noteVM = parameter as NoteViewModel;
            if (noteVM == null)
                return;
            noteVM.Delete();
        }
    }
}
