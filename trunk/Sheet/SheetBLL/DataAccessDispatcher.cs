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
            throw new NotImplementedException();
        }

        public Facade.Notes.IAttachment CreateAttachment()
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.ILabel CreateLabel()
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.IMetainfo CreateMetainfo()
        {
            throw new NotImplementedException();
        }

        public bool SaveNote(Facade.Notes.INote note)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNote(Facade.Notes.INote note)
        {
            throw new NotImplementedException();
        }

        public ICollection<Facade.Notes.ILabel> GetLabels()
        {
            return service.GetLabels();
        }

        public Facade.Notes.INote LoadNote(Facade.Notes.INote note)
        {
            throw new NotImplementedException();
        }

        public ICollection<Facade.Notes.INote> QueryNotes(string expression)
        {
            throw new NotImplementedException();
        }

        public ICollection<Facade.Notes.INote> QueryNotes(Facade.Notes.ILabel label)
        {
            throw new NotImplementedException();
        }

        public ICollection<Facade.Notes.INote> QueryNotes(Facade.Queries.NoteQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
