using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sheet.Facade.Notes
{
    public interface IAttachment : IEntity
    {
        string Name { get; set; }
        Stream File { get; set; }
        string MimeType { get; set; }
        ICollection<IMetainfo> Metadata { get; }
    }
}
