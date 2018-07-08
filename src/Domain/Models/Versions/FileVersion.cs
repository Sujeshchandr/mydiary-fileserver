using MyDiary.FileServer.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDiary.FileServer.Domain.Models
{
    public class FileVersion : StoredObject
    {
        public string Id { get; set; }

        public int VersionNumber { get; set; }

        public string Name { get; set; }       
    }
}