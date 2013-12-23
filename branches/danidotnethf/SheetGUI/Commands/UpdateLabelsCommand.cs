using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sheet.GUI.Commands
{
    public class UpdateLabelsCommand : ViewModelCommand<NoteViewModel>
    {
        public UpdateLabelsCommand(NoteViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var labels = parameter as string[];
            if (labels == null)
                return;
            vm.UpdateLabels(labels);
        }
    }
}
