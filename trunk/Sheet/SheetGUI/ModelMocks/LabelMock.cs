using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ModelMocks
{
    class LabelMock : ModelMock, ILabel
    {
        public string Text
        {
            get;
            set;
        }

        private List<INote> notes = new List<INote>();
        public ICollection<INote> Notes
        {
            get { return notes; }
        }

        public int ID
        {
            get { return -1; }
        }
    }
}
