using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLL
{
    public class LocalNoteService : INoteService
    {
        private static IDataService dal = new DataAccessDispatcher();

        public static IDataService Dal
        {
            get { return dal; }
        }

        public LocalNoteService()
        {

        }

        public ICollection<Facade.Notes.ILabel> GetLabels()
        {
            return Dal.GetLabels();
        }

        public ICollection<Facade.Notes.INote> GetNotesByLabel(Facade.Notes.ILabel label)
        {
            return Dal.QueryNotes(label);
        }

        public Facade.Notes.INote LoadNote(Facade.Notes.INote note)
        {
            return Dal.LoadNote(note);
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


        public Facade.Notes.INote NewNote()
        {
            throw new NotImplementedException();
        }
    }
}
