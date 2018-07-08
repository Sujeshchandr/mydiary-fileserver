using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel =  MyDiary.FileServer.Domain.Models;
namespace MyDiary.FileServer.DataAccess.MongoDb.UploadSession.Contracts
{
    public interface IUploadSessionDataAccess
    {
        Task SaveAsync(DomainModel.UploadSessons.UploadSession uploadSession);
    }
}
