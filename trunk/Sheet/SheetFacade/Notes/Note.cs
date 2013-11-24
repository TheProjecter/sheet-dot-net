using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheetFacade.Notes
{
    interface Note
    {
        string Title { get; set; }
        DateTime DateOfCreation { get; set; }
        DateTime LastModified { get; set; }
        IList<Label> Labels { get; }
    }
}
