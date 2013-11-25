using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLL
{
    class LocalNoteService : NoteService
    {

        public ICollection<Facade.Notes.Label> GetUsedLabels()
        {
            throw new NotImplementedException();
        }

        public ICollection<Facade.Notes.Note> GetNotesByLabel(Facade.Notes.Label label)
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.Note LoadNote(Facade.Notes.Note note)
        {
            throw new NotImplementedException();
        }
    }
}
