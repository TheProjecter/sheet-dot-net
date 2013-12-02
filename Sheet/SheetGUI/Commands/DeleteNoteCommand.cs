using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace Sheet.GUI.Commands
{
    public class DeleteNoteCommand : ViewModelCommand<MainViewModel>
    {
        public DeleteNoteCommand(MainViewModel vm) : base(vm) 
        {
            vm.PropertyChanged += vm_PropertyChanged;
        }

        void vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedNote" || e.PropertyName == string.Empty)
            {
                base.RaiseCanExecutedChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            //NoteViewModel noteVM = parameter as NoteViewModel;
            //return noteVM != null;
            return vm.SelectedNote != null;
        }

        public override void Execute(object parameter)
        {
            NoteViewModel noteVM = parameter as NoteViewModel;
            if (noteVM == null)
                return;

            if (MessageBox.Show("Are you sure you want to delete this note? All saved data will be lost.", "Warning", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Warning) == System.Windows.MessageBoxResult.No)
                return;

            if (vm.OpenNotes.Contains(noteVM))
                vm.OpenNotes.Remove(noteVM);
            noteVM.Delete();
        }
    }
}
