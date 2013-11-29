using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheet.Facade.Notes;
using Sheet.Facade.Queries;

namespace Sheet.Facade.Services
{
    public interface IDataService
    {
        INote CreateNote();
        IAttachment CreateAttachment();
        ILabel CreateLabel();
        IMetainfo CreateMetainfo();

        bool SaveNote(INote note);
        bool DeleteNote(INote note);

        ICollection<ILabel> GetLabels();

        INote LoadNote(INote note);
        ICollection<INote> QueryNotes(string expression);
        ICollection<INote> QueryNotes(ILabel label);
        ICollection<INote> QueryNotes(NoteQuery query);
    }
}
