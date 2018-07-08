using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Services.File.Core.Contract
{
    public interface IFileService
    {
        Task<string> GetNameAsync(string containerName, string fileId);
    }
}
