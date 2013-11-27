using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.Facade.Services
{
    public interface NoteService
    {
        ICollection<Label> GetLabels();
        ICollection<Note> GetNotesByLabel(Label label);
        Note LoadNote(Note note);
    }
}
