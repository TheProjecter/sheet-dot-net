using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.Commands
{
    public class SimpleSearchCommand : ViewModelCommand<MainViewModel>
    {
        public SimpleSearchCommand(MainViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public async override void Execute(object parameter)
        {
            string expression = parameter as string;
            if (string.IsNullOrEmpty(expression))
            {
                vm.SearchResultsVisibility = System.Windows.Visibility.Collapsed;
                vm.SearchResults.Clear();
                return;
            }
            else
            {
                var results = await App.Bll.SearchNote(expression);
                vm.SearchResultsVisibility = System.Windows.Visibility.Visible;
                vm.SearchResults.Clear();
                foreach (var note in results)
                {
                    vm.SearchResults.Add(vm.GetViewModel(note));
                }
            }
        }
    }
}
