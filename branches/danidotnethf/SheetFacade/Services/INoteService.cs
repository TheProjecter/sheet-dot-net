using Sheet.Facade.Notes;
using Sheet.Facade.Queries.ComplexQueries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.Facade.Services
{
    public interface INoteService
    {
        ICollection<INote> GetNotes();
        ICollection<INote> GetNotesByLabel(ILabel label);
        ICollection<INote> SearchNote(string expression);
        ICollection<INote> SearchNote(ComplexQuery query);
        INote LoadNote(INote note);
        INote UpdateLabels(INote note, IEnumerable<string> labels);
        INote AddAttachment(INote note, Stream attachment, string fileName);
        Stream DownloadAttachment(IAttachment attachment);
        INote NewNote();
        void SaveNote(INote note);
        void DeleteNote(INote note);
        void DeleteAttachment(IAttachment attachment);
    }
}
