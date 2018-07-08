using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDiary.FileServer.Domain.Models.UploadSessons
{
    public class UploadSession
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public long Length { get; set; }
    }
}