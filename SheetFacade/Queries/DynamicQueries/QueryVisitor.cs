using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.Facade.Queries
{
    public interface QueryVisitor
    {
        void Visit(TitleQuery query);
        void Visit(ContentQuery query);
        void Visit(LabelQuery query);
        void Visit(AndQuery query);
        void Visit(OrQuery query);
    }
}
