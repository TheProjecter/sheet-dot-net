using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLL
{
    public class LocalNoteService : NoteService
    {
        private static DataService dal = new DataAccessDispatcher();

        public static DataService Dal
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
    }
}
