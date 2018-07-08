using MyDiary.FileServer.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Reference
{
    public sealed class FileVersionReference : StoredObjectReference
    {
         public string FileId { get; set; }

         public int  FileVersionNumber { get; set; }

         public FileVersionReference()
             : base()
         {
         }

         public FileVersionReference(string containerName, string fileId, int fileVersionNumber)
            : base(containerName)
        {
            if (fileId == null)
            {
                throw new ArgumentNullException("fileId");
            }

            FileId = fileId;
            FileVersionNumber = fileVersionNumber;
        }
    }
}
