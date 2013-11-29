using Sheet.BLL;
using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI
{
    public class BusinessLogicDispatcher : INoteService
    {
        INoteService service;

        public BusinessLogicDispatcher()
        {
            service = new LocalNoteService();
        }

        public ICollection<Facade.Notes.ILabel> GetLabels()
        {
            return service.GetLabels();
        }

        public ICollection<Facade.Notes.INote> GetNotesByLabel(Facade.Notes.ILabel label)
        {
            return service.GetNotesByLabel(label);
        }

        public Facade.Notes.INote LoadNote(Facade.Notes.INote note)
        {
            return service.LoadNote(note);
        }


        public ICollection<Facade.Notes.INote> SearchNote(string expression)
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.INote UpdateLabels(Facade.Notes.INote note, IEnumerable<string> labels)
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.INote AddAttachment(Facade.Notes.INote note, System.IO.Stream attachment)
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.INote SaveNote(Facade.Notes.INote note)
        {
            throw new NotImplementedException();
        }

        public void DeleteNote(Facade.Notes.INote note)
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.INote DeleteAttachment(Facade.Notes.INote note, Facade.Notes.IAttachment attachment)
        {
            throw new NotImplementedException();
        }
    }
}
