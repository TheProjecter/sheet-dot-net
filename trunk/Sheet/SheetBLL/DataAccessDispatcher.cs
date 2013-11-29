using Sheet.DAL;
using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLL
{
    public class DataAccessDispatcher : DataService
    {
        private DataService service;

        public DataAccessDispatcher()
        {
            service = new SqlCeDataService();
        }

        public Facade.Notes.INote CreateNote()
        {
            return service.CreateNote();
        }

        public Facade.Notes.IAttachment CreateAttachment()
        {
            return service.CreateAttachment();
        }

        public Facade.Notes.ILabel CreateLabel()
        {
            return service.CreateLabel();
        }

        public Facade.Notes.IMetainfo CreateMetainfo()
        {
            return service.CreateMetainfo();
        }

        public bool SaveNote(Facade.Notes.INote note)
        {
            return service.SaveNote(note);
        }

        public bool DeleteNote(Facade.Notes.INote note)
        {
            return service.DeleteNote(note);
        }

        public ICollection<Facade.Notes.ILabel> GetLabels()
        {
            return service.GetLabels();
        }

        public Facade.Notes.INote LoadNote(Facade.Notes.INote note)
        {
            return service.LoadNote(note);
        }

        public ICollection<Facade.Notes.INote> QueryNotes(string expression)
        {
            return service.QueryNotes(expression);
        }

        public ICollection<Facade.Notes.INote> QueryNotes(Facade.Notes.ILabel label)
        {
            return service.QueryNotes(label);
        }

        public ICollection<Facade.Notes.INote> QueryNotes(Facade.Queries.NoteQuery query)
        {
            return service.QueryNotes(query);
        }
    }
}
