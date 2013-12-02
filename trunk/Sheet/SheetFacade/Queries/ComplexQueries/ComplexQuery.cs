using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.Facade.Queries.ComplexQueries
{
    public class ComplexQuery
    {
        public IEnumerable<string> TitleQuery { get; set; }
        public IEnumerable<string> TitleAny { get; set; }
        public IEnumerable<string> TextQuery { get; set; }
        public IEnumerable<string> TextAny { get; set; }
        public IEnumerable<string> LabelQuery { get; set; }
        public DateTime Before { get; set; }
        public DateTime After { get; set; }
        public IEnumerable<ContentType> HasAttachment { get; set; }
        public IEnumerable<string> AttachmentNameQuery { get; set; }
    }
}
