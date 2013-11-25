using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.Facade.Notes
{
    public interface Note
    {
        string Title { get; set; }
        string Text { get; set; }
        DateTime DateOfCreation { get; set; }
        DateTime LastModified { get; set; }
        IList<Label> Labels { get; }
    }
}
