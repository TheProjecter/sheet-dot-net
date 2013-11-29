using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Input;

namespace Sheet.GUI.Commands
{
    class OpenNoteCommand : GlobalCommand
    {
        private bool doubleClick = false;
        private object doubleParamter = null;
        private Timer timer = new Timer(1000);

        public OpenNoteCommand(MainViewModel main) : base(main)
        {
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            doubleClick = false;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public override void Execute(object parameter)
        {
            if (doubleClick && doubleParamter == parameter)
            {
                doubleClick = false;
                doubleParamter = null;
                timer.Stop();
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
                doubleParamter = parameter;
                timer.Start();
            }
        }
    }
}
