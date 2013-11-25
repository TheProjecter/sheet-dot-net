using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.DAL.Entities
{
    class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
