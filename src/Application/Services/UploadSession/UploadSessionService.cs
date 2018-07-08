using MyDiary.FileServer.Application.Providers.Contract;
using MyDiary.FileServer.Application.Reference;
using MyDiary.FileServer.Application.Services.UploadSession.Contract;
using MyDiary.FileServer.DataAccess.Memory.UploadSession.Contract;
using MyDiary.FileServer.Domain.Models.UploadSessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Services.UploadSession
{
    public class UploadSessionService : IUploadSessionService
    {

        public  Task<string> GetNameAsync(string containerName, string uploadSessionId)
        {
            throw new NotImplementedException();
        }
    }
}
