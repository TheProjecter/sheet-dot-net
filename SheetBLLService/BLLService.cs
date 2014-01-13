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
    public partial class BLLService : IBLLService
    {
        INoteService service;

        public BLLService()
        {
            service = new Sheet.BLL.LocalNoteService();
        }

        public ICollection<Note> GetNotes()
        {
            Dictionary<int, ILabel> dalLables = new Dictionary<int, ILabel>();

            ICollection<Note> result = new List<Note>();
            ICollection<INote> dalNotes = service.GetNotes();

            foreach (INote note in dalNotes)
            {
                foreach (ILabel label in note.Labels)
                {
                    if (!dalLables.ContainsKey(label.ID))
                    {
                        dalLables.Add(label.ID, label);
                    }
                }
            }

            foreach (INote note in dalNotes)
            {
                result.Add(new Note(note));
            }
            foreach (ILabel dalLabel in dalLables.Values)
            {
                Label label = new Label(dalLabel);
                foreach (Note note in result)
                {
                    if (dalLabel.Notes.Select(n => n.ID).Contains(note.ID))
                    {
                        if (!label.Notes.Contains(note))
                        {
                            label.Notes.Add(note); 
                        }
                        if (!note.Labels.Contains(label))
                        {
                            note.Labels.Add(label);
                        }
                    }
                }
            }

            return result;
        }

        public ICollection<Note> GetNotesByLabel(Label label)
        {
            ICollection<Note> result = new List<Note>();
            foreach (INote note in service.GetNotesByLabel(label))
            {
                result.Add(new Note(note));
            }
            return result;
        }

        //public ICollection<Note> SearchNote(string expression)
        //{
        //    ICollection<Note> result = new List<Note>();
        //    foreach (INote note in service.SearchNote(expression))
        //    {
        //        result.Add(new Note(note));
        //    }
        //    return result;
        //}

        //public ICollection<Note> SearchNoteQuery(ComplexQuery query)
        //{
        //    ICollection<Note> result = new List<Note>();
        //    foreach (INote note in service.SearchNote(query))
        //    {
        //        result.Add(new Note(note));
        //    }
        //    return result;
        //}

        public Note LoadNote(Note note)
        {
            return new Note(service.LoadNote(note));
        }

        //public Note UpdateLabels(INote note, IEnumerable<string> labels)
        //{
        //    return new Note(service.UpdateLabels(note, labels));
        //}

        //public void AddAttachment(AttachmentInfo attachmentInfo)
        //{
        //    service.AddAttachment(attachmentInfo.Note, attachmentInfo.AttachmentStream, attachmentInfo.FileName);
        //}

        //public System.IO.Stream DownloadAttachment(IAttachment attachment)
        //{
        //    return service.DownloadAttachment(attachment);
        //}

        //public Note NewNote()
        //{
        //    return new Note(service.NewNote());
        //}

        public void SaveNote(Note note)
        {
            service.SaveNote(note);
        }

        //public void DeleteNote(INote note)
        //{
        //    service.DeleteNote(note);
        //}

        //public void DeleteAttachment(IAttachment attachment)
        //{
        //    service.DeleteAttachment(attachment);
        //}
    }
}
