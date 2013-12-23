using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLLService.Entities
{

    [MessageContract]
    public class AttachmentInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public INote Note;

        [MessageBodyMember(Order = 1)]
        public System.IO.Stream AttachmentStream;

        public void Dispose()
        {
            if (AttachmentStream != null)
            {
                AttachmentStream.Close();
                AttachmentStream = null;
            }
        }

    }
}
