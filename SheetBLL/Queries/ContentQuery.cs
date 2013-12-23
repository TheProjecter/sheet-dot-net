using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLL.Queries
{
    class ContentQuery : Sheet.Facade.Queries.ContentQuery
    {
        public string Expression
        {
            get { throw new NotImplementedException(); }
        }

        public void Accept(Facade.Queries.QueryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
