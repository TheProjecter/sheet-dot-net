using Sheet.BLLService.Entities;
using Sheet.Facade.Notes;
using Sheet.Facade.Queries.ComplexQueries;
using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Sheet.BLLService
{
    public class BLLService : IBLLService
    {
        INoteService service;

        public BLLService()
        {
            service = new Sheet.BLL.LocalNoteService();
        }

        public ICollection<Note> GetNotes()
        {
            ICollection<Note> result = new List<Note>();
            foreach (INote note in service.GetNotes())
            {
                result.Add(new Note(note));
            }
            return result;
        }

        public ICollection<Note> GetNotesByLabel(Facade.Notes.ILabel label)
        {
            ICollection<Note> result = new List<Note>();
            foreach (INote note in service.GetNotesByLabel(label))
            {
                result.Add(new Note(note));
            }
            return result;
        }

        public ICollection<Note> SearchNote(string expression)
        {
            ICollection<Note> result = new List<Note>();
            foreach (INote note in service.SearchNote(expression))
            {
                result.Add(new Note(note));
            }
            return result;
        }

        public ICollection<Note> SearchNoteQuery(ComplexQuery query)
        {
            ICollection<Note> result = new List<Note>();
            foreach (INote note in service.SearchNote(query))
            {
                result.Add(new Note(note));
            }
            return result;
        }

        public Note LoadNote(INote note)
        {
            return new Note(service.LoadNote(note));
        }

        public Note UpdateLabels(INote note, IEnumerable<string> labels)
        {
            return new Note(service.UpdateLabels(note, labels));
        }

        public void AddAttachment(AttachmentInfo attachmentInfo)
        {
            service.AddAttachment(attachmentInfo.Note, attachmentInfo.AttachmentStream, attachmentInfo.FileName);
        }

        public System.IO.Stream DownloadAttachment(IAttachment attachment)
        {
            return service.DownloadAttachment(attachment);
        }

        public Note NewNote()
        {
            return new Note(service.NewNote());
        }

        public void SaveNote(INote note)
        {
            service.SaveNote(note);
        }

        public void DeleteNote(INote note)
        {
            service.DeleteNote(note);
        }

        public void DeleteAttachment(IAttachment attachment)
        {
            service.DeleteAttachment(attachment);
        }
    }
}
