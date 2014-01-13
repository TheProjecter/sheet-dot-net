using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Sheet.Facade.Notes;

namespace Sheet.BLLService.Entities
{
    [DataContract]
    public class Attachment : IAttachment
    {
        public Attachment(IAttachment attachment)
        {
            this.Metadata = new List<Metainfo>();

            this.ID = attachment.ID;
            this.Name = attachment.Name;
            this.Path = attachment.Path;
            this.MimeType = attachment.MimeType;
            foreach (IMetainfo metainfo in attachment.Metadata)
            {
                this.Metadata.Add(new Metainfo(metainfo));
            }
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Path { get; set; }
        [DataMember]
        public string MimeType { get; set; }
        [DataMember]
        public ICollection<Metainfo> Metadata { get; private set; }
        [DataMember]
        public int ID { get; private set; }


        ICollection<IMetainfo> IAttachment.Metadata
        {
            get { throw new NotImplementedException(); }
        }
    }
}
