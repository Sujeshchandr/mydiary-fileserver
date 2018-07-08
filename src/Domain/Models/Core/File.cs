using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDiary.FileServer.Domain.Models.Core
{
    public class File : StoredObject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<FileVersion> Versions { get; set; }
    }
}