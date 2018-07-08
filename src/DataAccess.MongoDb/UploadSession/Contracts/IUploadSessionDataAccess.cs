using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDiary.FileServer.Domain.Models;
namespace DataAccess.MongoDb.UploadSession.Contracts
{
    public interface IUploadSessionDataAccess
    {
        Task SaveAsync(MyDiary.FileServer.Domain.Models.UploadSessons.UploadSession uploadSession);
    }
}
