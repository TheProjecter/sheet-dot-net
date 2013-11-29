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
    }
}
