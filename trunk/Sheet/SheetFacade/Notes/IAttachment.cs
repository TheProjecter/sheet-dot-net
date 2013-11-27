using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.Facade.Notes
{
    public interface IAttachment : IEntity
    {
        string Name { get; set; }
        string Path { get; set; }
        string MimeType { get; set; }
        ICollection<IMetainfo> Metadata { get; }
    }
}
