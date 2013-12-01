using Sheet.Facade.Notes;
using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
            Dal.DeleteLabels(note);
            foreach (var label in labels)
            {
                Dal.SetLabel(note, label);
            }
            return Dal.LoadNote(note);
        }

        public Facade.Notes.INote AddAttachment(Facade.Notes.INote note, System.IO.Stream sourceStream, string fileName)
        {
            IAttachment attachment = Dal.CreateAttachment(note, sourceStream, fileName);
            ExtractMetadata(attachment);
            return Dal.LoadNote(note);
        }

        private void ExtractMetadata(IAttachment attachment)
        {
            //throw new NotImplementedException();
        }

        public void SaveNote(Facade.Notes.INote note)
        {
            Dal.SaveNote(note);
        }

        public void DeleteNote(Facade.Notes.INote note)
        {
            Dal.DeleteNote(note);
        }

        public void DeleteAttachment(Facade.Notes.IAttachment attachment)
        {
            Dal.DeleteAttachment(attachment);
        }


        public Facade.Notes.INote NewNote()
        {
            INote newNote = Dal.CreateNote();
            return Dal.LoadNote(newNote);
        }

        public Stream DownloadAttachment(IAttachment attachment)
        {
            return Dal.DownloadAttachment(attachment);
        }
    }
}
