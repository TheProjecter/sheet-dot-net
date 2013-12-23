using Sheet.BLL;
using Sheet.Facade.Notes;
using Sheet.Facade.Services;
using Sheet.GUI.SheetServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI
{
    public class BusinessLogicDispatcher
    {
        IBLLService service; 
        

        public BusinessLogicDispatcher()
        {
            service = new BLLServiceClient();
        }

        public async Task<ICollection<Facade.Notes.INote>> GetNotes()
        {
            return await Task<ICollection<Sheet.Facade.Notes.INote>>.Run((() => service.GetNotes() as ICollection<INote>));
        }

        public async Task<ICollection<Facade.Notes.INote>> GetNotesByLabel(Facade.Notes.ILabel label)
        {
            return await Task<ICollection<Sheet.Facade.Notes.INote>>.Run(() => service.GetNotesByLabel(label) as ICollection<INote>);
        }

        public async Task<Facade.Notes.INote> LoadNote(Facade.Notes.INote note)
        {
            return await Task<Sheet.Facade.Notes.INote>.Run(() => service.LoadNote(note) as INote);
        }

        public async Task<ICollection<Facade.Notes.INote>> SearchNote(string expression)
        {
            return await Task<ICollection<Sheet.Facade.Notes.INote>>.Run(() => service.SearchNote(expression) as ICollection<INote>);
        }

        public async Task<Facade.Notes.INote> UpdateLabels(Facade.Notes.INote note, IEnumerable<string> labels)
        {
            return await Task<Sheet.Facade.Notes.INote>.Run(() => service.UpdateLabels(note, (string[])labels) as INote);
        }

        public async Task<Facade.Notes.INote> AddAttachment(Facade.Notes.INote note, System.IO.Stream attachment, string fileName)
        {
            AttachmentInfo attachmentInfo = new AttachmentInfo
            {
                FileName = fileName,
                Note = note,
                AttachmentStream = attachment
            };
            return await Task<Sheet.Facade.Notes.INote>.Run(() => service.AddAttachment(attachmentInfo) as INote);
        }

        public async Task SaveNote(Facade.Notes.INote note)
        {
            await Task.Run(() => service.SaveNote(note));
        }

        public async Task DeleteNote(Facade.Notes.INote note)
        {
            await Task.Run(() => service.DeleteNote(note));
        }

        public async Task DeleteAttachment(Facade.Notes.IAttachment attachment)
        {
            await Task.Run(() => service.DeleteAttachment(attachment));
        }


        public async Task<Facade.Notes.INote> NewNote()
        {
            return await Task.Run<Sheet.Facade.Notes.INote>(() => service.NewNote() as INote);
        }


        public async Task<System.IO.Stream> DownloadAttachment(Facade.Notes.IAttachment attachment)
        {
            return await Task<System.IO.Stream>.Run(() => service.DownloadAttachment(attachment));
        }


        public async Task<ICollection<Facade.Notes.INote>> SearchNote(Facade.Queries.ComplexQueries.ComplexQuery query)
        {
            // TODO: Complex Query
            return await Task<ICollection<Sheet.Facade.Notes.INote>>.Run(() => service.SearchNote("alma") as ICollection<INote>);
        }
    }
}
