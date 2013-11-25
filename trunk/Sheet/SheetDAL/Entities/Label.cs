using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sheet.DAL.Entities
{
    class Label : Sheet.Facade.Notes.Label
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
