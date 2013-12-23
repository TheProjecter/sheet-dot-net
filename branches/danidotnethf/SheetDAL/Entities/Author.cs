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

        private ICollection<Note> _notes;
        public virtual ICollection<Note> Notes
        {
            get
            {
                return _notes ?? (_notes = new List<Note>());
            }
            set
            {
                _notes = value;
            }
        }
    }
}
