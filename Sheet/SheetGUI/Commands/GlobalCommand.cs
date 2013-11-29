using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sheet.GUI.Commands
{
    public abstract class GlobalCommand : ICommand
    {
        protected MainViewModel main;

        public GlobalCommand(MainViewModel main)
        {
            this.main = main;
        }

        public abstract bool CanExecute(object parameter);

        public event EventHandler CanExecuteChanged;

        public abstract void Execute(object parameter);
    }
}
