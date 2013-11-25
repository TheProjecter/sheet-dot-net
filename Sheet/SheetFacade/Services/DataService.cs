using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheet.Facade.Notes;
using Sheet.Facade.Queries;

namespace Sheet.Facade.Services
{
    public interface DataService
    {
        Note CreateNote();
        Attachment CreateAttachment();
        Label CreateLabel();
        Metainfo CreateMetainfo();

        bool SaveNote(Note note);

        bool DeleteNote(Note note);

        Note LoadNote(Note note);
        ICollection<Note> QueryNotes(Label label);
        ICollection<Note> QueryNotes(NoteQuery query);
    }
}
