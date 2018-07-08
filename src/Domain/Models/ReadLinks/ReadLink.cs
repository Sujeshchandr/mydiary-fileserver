using MyDiary.FileServer.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Domain.Models.ReadLinks
{
    public class ReadLink
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<StoredObject> StoredObject { get; set; }

        //public IEnumerable<StoredObjectReference> StoredObjectReference { get; set; }

        //public StoredObjectReference StoredObjectReference { get; set; }

    }
}
