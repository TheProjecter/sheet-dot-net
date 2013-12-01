using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ModelMocks
{
    class NoteMock : ModelMock, INote
    {
        public string Title
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public DateTime DateOfCreation
        {
            get;
            set;
        }

        public DateTime LastModified
        {
            get;
            set;
        }

        private List<ILabel> labels = new List<ILabel>();
        public ICollection<ILabel> Labels
        {
            get { return labels; }
        }

        private List<IAttachment> attachments = new List<IAttachment>();
        public ICollection<IAttachment> Attachments
        {
            get { return attachments; }
        }

        public int ID
        {
            get { return -1; }
        }
    }
}
