using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.Facade.Notes
{
    public interface INote : IEntity
    {
        string Title { get; set; }
        string Text { get; set; }
        DateTime DateOfCreation { get; set; }
        DateTime LastModified { get; set; }
        ICollection<ILabel> Labels { get; }
        ICollection<IAttachment> Attachments { get; }
    }
}
