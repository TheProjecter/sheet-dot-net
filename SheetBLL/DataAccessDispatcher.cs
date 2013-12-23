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


        public Facade.Notes.IMetainfo CreateMetainfo(Facade.Notes.IAttachment attachment)
        {
            return service.CreateMetainfo(attachment);
        }



        public ICollection<Facade.Notes.INote> GetNotes()
        {
            return service.GetNotes();
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


        public Facade.Notes.IAttachment CreateAttachment(Facade.Notes.INote note, System.IO.Stream file, string fileName)
        {
            return service.CreateAttachment(note, file, fileName);
        }

        public void DeleteNote(Facade.Notes.INote note)
        {
            service.DeleteNote(note);
        }

        public void DeleteAttachment(Facade.Notes.IAttachment attachment)
        {
            service.DeleteAttachment(attachment);
        }

        public void SaveNote(Facade.Notes.INote note)
        {
            service.SaveNote(note);
        }

        public Facade.Notes.ILabel SetLabel(Facade.Notes.INote note, string text)
        {
            return service.SetLabel(note, text);
        }


        public System.IO.Stream DownloadAttachment(Facade.Notes.IAttachment attachment)
        {
            return service.DownloadAttachment(attachment);
        }


        public void DeleteLabels(Facade.Notes.INote note)
        {
            service.DeleteLabels(note);
        }


        public ICollection<Facade.Notes.INote> QueryNotes(Facade.Queries.ComplexQueries.ComplexQuery query)
        {
            return service.QueryNotes(query);
        }
    }
}
