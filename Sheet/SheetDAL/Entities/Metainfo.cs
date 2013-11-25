using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.DAL.Entities
{
    class Metainfo : Sheet.Facade.Notes.Metainfo
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
