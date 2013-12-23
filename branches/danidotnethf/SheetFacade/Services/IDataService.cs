using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheet.Facade.Notes;
using Sheet.Facade.Queries;
using System.IO;
using Sheet.Facade.Queries.ComplexQueries;

namespace Sheet.Facade.Services
{
    public interface IDataService
    {
        INote CreateNote();
        IAttachment CreateAttachment(INote note, Stream file, string fileName);
        Stream DownloadAttachment(IAttachment attachment);
        IMetainfo CreateMetainfo(IAttachment attachment);
        void DeleteNote(INote note);
        void DeleteAttachment(IAttachment attachment);
        void DeleteLabels(INote note);
        

        void SaveNote(INote note);

        ICollection<INote> GetNotes();
        ILabel SetLabel(INote note, string text);

        INote LoadNote(INote note);
        ICollection<INote> QueryNotes(string expression);
        ICollection<INote> QueryNotes(ILabel label);
        ICollection<INote> QueryNotes(NoteQuery query);
        ICollection<INote> QueryNotes(ComplexQuery query);
    }
}
