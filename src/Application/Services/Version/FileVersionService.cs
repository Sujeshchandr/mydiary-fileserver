using MyDiary.FileServer.Application.Providers.Contract;
using MyDiary.FileServer.Application.Reference;
using MyDiary.FileServer.Application.Services.Version.Contract;
using MyDiary.FileServer.DataAccess.Memory.FileVersion.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Services.Version
{
    public class FileVersionService : IFileVersionService
    {
       public FileVersionService()
        {
           
        }

       public Task<string> GetNameAsync(string containerName, string fileId, int fileVersionNumber)
       {
           throw new NotImplementedException();
       }
    }
}
