using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sheet.GUI.Commands
{
    public class UpdateLabelsCommand : ICommand
    {
        private NoteViewModel vm;

        public UpdateLabelsCommand(NoteViewModel vm)
        {
            this.vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var labels = parameter as string[];
            if (labels == null)
                return;
            vm.UpdateLabels(labels);
        }
    }
}
