using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ModelMocks
{
    class AttachmentMock : ModelMock, IAttachment
    {
        public string Name
        {
            get;
            set;
        }

        public System.IO.Stream File
        {
            get;
            set;
        }

        public string MimeType
        {
            get;
            set;
        }

        private List<IMetainfo> metadata = new List<IMetainfo>();
        public ICollection<IMetainfo> Metadata
        {
            get { return metadata; }
        }

        public int ID
        {
            get { return -1; }
        }
    }
}
