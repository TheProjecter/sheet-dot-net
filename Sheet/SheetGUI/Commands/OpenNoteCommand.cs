using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Input;

namespace Sheet.GUI.Commands
{
    class OpenNoteCommand : ICommand
    {
        private MainViewModel main;

        private bool doubleClick = false;
        private Timer timer = new Timer(500);

        public OpenNoteCommand(MainViewModel main)
        {
            this.main = main;
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            doubleClick = false;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (doubleClick)
            {
                doubleClick = false;
                NoteViewModel noteVM = parameter as NoteViewModel;
                if (noteVM == null)
                    return;
                if (!main.OpenNotes.Contains(noteVM))
                    main.OpenNotes.Add(noteVM);

                main.SelectedNote = noteVM;
            }
            else
            {
                doubleClick = true;
            }
        }
    }
}
