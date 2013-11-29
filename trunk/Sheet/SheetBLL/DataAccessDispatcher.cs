using Sheet.DAL;
using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLL
{
    public class DataAccessDispatcher : IDataService
    {
        private IDataService service;

        public DataAccessDispatcher()
        {
            service = new SqlCeDataService();
        }

        public Facade.Notes.INote CreateNote()
        {
            return service.CreateNote();
        }


        public Facade.Notes.IMetainfo CreateMetainfo()
        {
            return service.CreateMetainfo();
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


        public Facade.Notes.IAttachment CreateAttachment(Facade.Notes.INote note, System.IO.Stream file)
        {
            throw new NotImplementedException();
        }

        void IDataService.DeleteNote(Facade.Notes.INote note)
        {
            throw new NotImplementedException();
        }

        public void DeleteAttachment(Facade.Notes.INote note, Facade.Notes.IAttachment attachment)
        {
            throw new NotImplementedException();
        }

        void IDataService.SaveNote(Facade.Notes.INote note)
        {
            throw new NotImplementedException();
        }

        public Facade.Notes.ILabel GetLabel(Facade.Notes.INote note, string text)
        {
            throw new NotImplementedException();
        }
    }
}
