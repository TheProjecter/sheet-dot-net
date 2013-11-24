using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheetFacade.Notes
{
    interface Attachment
    {
        string Name { get; set; }
        string Path { get; set; }
        string MimeType { get; set; }
        IEnumerable<Metainfo> Metadata { get; }
    }
}
