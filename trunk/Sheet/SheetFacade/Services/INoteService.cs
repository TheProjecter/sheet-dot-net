using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.Facade.Services
{
    public interface INoteService
    {
        ICollection<ILabel> GetLabels();
        ICollection<INote> GetNotesByLabel(ILabel label);
        INote LoadNote(INote note);
    }
}
