﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.Facade.Queries
{
    public interface AtomicQuery : NoteQuery
    {
        string Expression { get; }
    }
}