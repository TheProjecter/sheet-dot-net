using Sheet.BLL;
using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI
{
    public class BusinessLogicDispatcher : NoteService
    {
        NoteService service;

        public BusinessLogicDispatcher()
        {
            service = new LocalNoteService();
        }

        public ICollection<Facade.Notes.Label> GetLabels()
        {
            return service.GetLabels();
        }

        public ICollection<Facade.Notes.Note> GetNotesByLabel(Facade.Notes.Label label)
        {
            return service.GetNotesByLabel(label);
        }

        public Facade.Notes.Note LoadNote(Facade.Notes.Note note)
        {
            return service.LoadNote(note);
        }
    }
}
