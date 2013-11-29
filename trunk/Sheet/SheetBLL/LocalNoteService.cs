using Sheet.Facade.Notes;
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
            return Dal.QueryNotes(expression);
        }

        public Facade.Notes.INote UpdateLabels(Facade.Notes.INote note, IEnumerable<string> labels)
        {
            int count = 0;
            foreach (var label in labels)
            {
                ++count;
                Dal.GetLabel(note, label);
            }
            if (count == 0)
            {
                //TODO: use resources instead!
                Dal.GetLabel(note, "No label");
            }
            return Dal.LoadNote(note);
        }

        public Facade.Notes.INote AddAttachment(Facade.Notes.INote note, System.IO.Stream data)
        {
            IAttachment attachment = Dal.CreateAttachment(note, data);
            ExtractMetadata(attachment, data);
            return Dal.LoadNote(note);
        }

        private void ExtractMetadata(IAttachment attachment, System.IO.Stream data)
        {
            throw new NotImplementedException();
        }

        public void SaveNote(Facade.Notes.INote note)
        {
            Dal.SaveNote(note);
        }

        public void DeleteNote(Facade.Notes.INote note)
        {
            Dal.DeleteNote(note);
        }

        public Facade.Notes.INote DeleteAttachment(Facade.Notes.INote note, Facade.Notes.IAttachment attachment)
        {
            Dal.DeleteAttachment(note, attachment);
            return Dal.LoadNote(note);
        }


        public Facade.Notes.INote NewNote()
        {
            INote newNote = Dal.CreateNote();
            //TODO: use resources instead!
            Dal.GetLabel(newNote, "No label");
            return Dal.LoadNote(newNote);
        }
    }
}
