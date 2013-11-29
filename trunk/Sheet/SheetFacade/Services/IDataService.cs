using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheet.Facade.Notes;
using Sheet.Facade.Queries;
using System.IO;

namespace Sheet.Facade.Services
{
    public interface IDataService
    {
        INote CreateNote();
        IAttachment CreateAttachment(INote note, Stream file);
        IMetainfo CreateMetainfo();
        void DeleteNote(INote note);
        void DeleteAttachment(INote note, IAttachment attachment);
        

        void SaveNote(INote note);

        ICollection<ILabel> GetLabels();
        ILabel GetLabel(INote note, string text);

        INote LoadNote(INote note);
        ICollection<INote> QueryNotes(string expression);
        ICollection<INote> QueryNotes(ILabel label);
        ICollection<INote> QueryNotes(NoteQuery query);
    }
}
