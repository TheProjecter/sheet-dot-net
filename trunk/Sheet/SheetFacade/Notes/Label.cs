using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.Facade.Notes
{
    public interface Label
    {
        string Text { get; set; }
        ICollection<Note> Notes { get; }
    }
}
