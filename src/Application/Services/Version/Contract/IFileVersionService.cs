using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Services.Version.Contract
{
    public interface IFileVersionService
    {
        Task<string> GetNameAsync(string containerName, string fileId, int fileVersionNumber);
    }
}
