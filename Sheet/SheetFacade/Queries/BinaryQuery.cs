using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.Facade.Queries
{
    interface BinaryQuery : NoteQuery
    {
        NoteQuery Left { get; }
        NoteQuery Right { get; }
    }
}
