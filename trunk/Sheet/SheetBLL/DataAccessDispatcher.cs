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

        public Facade.Notes.Note CreateNote()
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.Attachment CreateAttachment()
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.Label CreateLabel()
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.Metainfo CreateMetainfo()
        {
            throw new NotImplementedException();
        }

        public bool SaveNote(Facade.Notes.Note note)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNote(Facade.Notes.Note note)
        {
            throw new NotImplementedException();
        }

        public ICollection<Facade.Notes.Label> GetLabels()
        {
            return service.GetLabels();
        }

        public Facade.Notes.Note LoadNote(Facade.Notes.Note note)
        {
            throw new NotImplementedException();
        }

        public ICollection<Facade.Notes.Note> QueryNotes(string expression)
        {
            throw new NotImplementedException();
        }

        public ICollection<Facade.Notes.Note> QueryNotes(Facade.Notes.Label label)
        {
            throw new NotImplementedException();
        }

        public ICollection<Facade.Notes.Note> QueryNotes(Facade.Queries.NoteQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
