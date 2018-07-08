using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Domain.Models.Core
{
    public abstract class StoredObjectReference
    {
        public string ContainerName { get; set; }

        public StoredObjectReference() { }

        public StoredObjectReference(string containerName)
        {
            if (containerName == null)
            {
                throw new ArgumentNullException("containerName");
            }

            ContainerName = containerName;
        }
    }
}
