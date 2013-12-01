using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.Commands
{
    public class SimpleSearchCommand : GlobalCommand
    {
        public SimpleSearchCommand(MainViewModel main) : base(main) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            string expression = parameter as string;
            if (string.IsNullOrEmpty(expression))
            {
                main.SearchResultsVisibility = System.Windows.Visibility.Collapsed;
                main.SearchResults.Clear();
                return;
            }
            else
            {
                var results = App.Bll.SearchNote(expression);
                main.SearchResultsVisibility = System.Windows.Visibility.Visible;
                main.SearchResults.Clear();
                foreach (var note in results)
                {
                    main.SearchResults.Add(main.GetViewModel(note));
                }
            }
        }
    }
}
