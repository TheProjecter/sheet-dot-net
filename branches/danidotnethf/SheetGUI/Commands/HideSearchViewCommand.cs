﻿using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.Commands
{
    public class HideSearchViewCommand : ViewModelCommand<MainViewModel>
    {
        public HideSearchViewCommand(MainViewModel vm) : base(vm) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            vm.SearchResultsVisibility = System.Windows.Visibility.Collapsed;
        }
    }
}
