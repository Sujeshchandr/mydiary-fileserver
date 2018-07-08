using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Domain.Models.Core
{
    public abstract class StoredObject
    {
        public string ContainerName { get; set; }

        public string MediaContentType { get; set; }

        public int MediaContentLength { get; set; }
    }
}
