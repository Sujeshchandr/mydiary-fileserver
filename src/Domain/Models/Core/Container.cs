using MyDiary.FileServer.Domain.Models.ReadLinks;
using MyDiary.FileServer.Domain.Models.UploadSessons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyDiary.FileServer.Domain.Models.Core
{
    public class Container
    {
        [Key]
        public string ContainerName { get; set; }

        public IEnumerable<UploadSession> UploadSessions { get; set; }

        public IEnumerable<File> Files { get; set; }

        public IEnumerable<ReadLink> ReadLinks { get; set; }
    }
}