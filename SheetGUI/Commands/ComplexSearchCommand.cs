using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.Commands
{
    public class ComplexSearchCommand : ViewModelCommand<MainViewModel>
    {
        public ComplexSearchCommand(MainViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var complexSearchVM = parameter as ComplexSearchViewModel;
            if (complexSearchVM == null)
                return;
            complexSearchVM.Search();
        }
    }
}
