using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ModelMocks
{
    class MetainfoMock : ModelMock, IMetainfo
    {
        public string Key
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public int ID
        {
            get { return -1; }
        }
    }
}
