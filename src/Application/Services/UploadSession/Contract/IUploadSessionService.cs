using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Services.UploadSession.Contract
{
    public interface IUploadSessionService
    {
        Task<string> GetNameAsync(string containerName, string id);
    }
}
