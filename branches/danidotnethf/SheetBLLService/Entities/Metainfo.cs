using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLLService.Entities
{
    [DataContract]
    public class Metainfo : IMetainfo
    {
        public Metainfo(IMetainfo metainfo)
        {
            this.ID = metainfo.ID;
            this.Key = metainfo.Key;
            this.Value = metainfo.Value;
        }

        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public int ID { get; private set; }
    }
}
