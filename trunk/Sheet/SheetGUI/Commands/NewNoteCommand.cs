using Sheet.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Sheet.GUI.Commands
{
    public class NewNoteCommand : GlobalCommand
    {
        public NewNoteCommand(MainViewModel main) : base (main) { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public override void Execute(object parameter)
        {
            NoteViewModel newNoteVM = main.Factory.GetViewModel(App.Bll.NewNote());
            main.OpenNotes.Add(newNoteVM);
            main.SelectedNote = newNoteVM;
        }
    }
}
