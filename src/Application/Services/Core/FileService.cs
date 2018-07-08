using MyDiary.FileServer.Application.Providers.Contract;
using MyDiary.FileServer.Application.Reference;
using MyDiary.FileServer.Application.Services.File.Core.Contract;
using MyDiary.FileServer.DataAccess.Memory.File.Contract;
using MyDiary.FileServer.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Services.File.Core
{
    public class FileService : IFileService
    {
        public FileService()
        {
            
        }

        public Task<string> GetNameAsync(string containerName, string fileId)
        {
            throw new NotImplementedException();
        }
    }
}
