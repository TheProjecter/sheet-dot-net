﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLL.Queries
{
    class AndQuery : Sheet.Facade.Queries.AndQuery
    {
        public Facade.Queries.NoteQuery Left
        {
            get { throw new NotImplementedException(); }
        }

        public Facade.Queries.NoteQuery Right
        {
            get { throw new NotImplementedException(); }
        }

        public void Accept(Facade.Queries.QueryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
