using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.Facade.Notes
{
    public interface IMetainfo : IEntity
    {
        string Key { get; set; }
        string Value { get; set; }
    }
}
