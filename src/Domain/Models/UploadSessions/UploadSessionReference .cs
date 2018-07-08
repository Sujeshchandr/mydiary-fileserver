using MyDiary.FileServer.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Domain.Models.UploadSessons
{
    public sealed class UploadSessionReference : StoredObjectReference
    {
        public string UploadSessionId { get; set; }

        public UploadSessionReference() : base() { }

        public UploadSessionReference(string containerName, string uploadSessionId)
            : base(containerName)
        {
            if (uploadSessionId == null)
            {
                throw new ArgumentNullException("uploadSessionId");
            }

            UploadSessionId = uploadSessionId;
        }
    }
}
