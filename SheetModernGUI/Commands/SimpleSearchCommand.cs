﻿using Sheet.ModernGUI.ViewModel;
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
                var results = await App.Bll.SearchNote(expression);
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
