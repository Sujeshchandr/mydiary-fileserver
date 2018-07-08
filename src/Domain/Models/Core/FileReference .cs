using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Domain.Models.Core
{
    public sealed class FileReference : StoredObjectReference
    {
        public string FileId { get; set; }

        public FileReference() :base()
        {
        }

        public FileReference(string containerName, string fileId)
            : base(containerName)
        {
            if (fileId == null)
            {
                throw new ArgumentNullException("fileId");
            }

            FileId = fileId;
        }
    }
}
