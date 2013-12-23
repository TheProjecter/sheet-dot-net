using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.Facade.Notes
{
    public interface ILabel : IEntity
    {
        string Text { get; set; }
        ICollection<INote> Notes { get; }
    }
}
