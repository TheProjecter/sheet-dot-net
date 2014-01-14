using Sheet.ModernGUI.SheetServiceReference;
using Sheet.ModernGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Sheet.ModernGUI.Commands
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
            string expression = vm.SearchString;
            if (string.IsNullOrEmpty(expression))
            {
                vm.SearchResultsVisibility = Visibility.Collapsed;
                vm.SearchResults.Clear();
                return;
            }
            else
            {
                var allNotes = await App.Bll.GetNotes();
                var searchResults = await App.Bll.SearchNote(expression);
                var results = allNotes.Where(n => searchResults.Select(s => s.ID).Contains(n.ID));
                vm.SearchResultsVisibility = Visibility.Visible;
                vm.SearchResults.Clear();
                foreach (var note in results)
                {
                    vm.SearchResults.Add(vm.GetViewModel(note));
                }
            }
        }
    }
}
