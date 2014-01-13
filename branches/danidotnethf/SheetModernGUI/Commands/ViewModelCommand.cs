using Sheet.ModernGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sheet.ModernGUI.Commands
{
    public abstract class ViewModelCommand<T> : ICommand
    {
        protected T vm;

        public ViewModelCommand(T main)
        {
            this.vm = main;
        }

        public abstract bool CanExecute(object parameter);

        public event EventHandler CanExecuteChanged;

        public abstract void Execute(object parameter);

        protected void RaiseCanExecutedChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
    }
}
