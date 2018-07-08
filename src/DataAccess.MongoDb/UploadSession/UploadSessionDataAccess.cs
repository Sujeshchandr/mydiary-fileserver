using DataAccess.MongoDb.UploadSession.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDiary.FileServer.Domain.Models.UploadSessons;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess.MongoDb.UploadSession
{
    public class UploadSessionDataAccess : IUploadSessionDataAccess
    {
        public UploadSessionDataAccess(string connectionString, string name)
        {

        }

        public Task SaveAsync(MyDiary.FileServer.Domain.Models.UploadSessons.UploadSession uploadSession)
        {
            if (uploadSession == null)
            {
                throw new NotImplementedException(nameof(uploadSession));
            }

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<MyDiary.FileServer.Domain.Models.UploadSessons.UploadSession>("test");

            return collection.InsertOneAsync(uploadSession);
        }
    }
}
