﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Sheet.DAL.Entities
{
    class Metainfo : Sheet.Facade.Notes.IMetainfo
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
