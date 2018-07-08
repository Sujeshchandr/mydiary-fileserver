using MyDiary.FileServer.DataAccess.MongoDb.UploadSession.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDiary.FileServer.Domain.Models.UploadSessons;
using MongoDB.Bson;
using MongoDB.Driver;
using DomainModel = MyDiary.FileServer.Domain.Models;
using MyDiary.FileServer.MyDiary.FileServer.DataAccess.MongoDb;

namespace MyDiary.FileServer.DataAccess.MongoDb.UploadSession
{
    public class UploadSessionDataAccess : IUploadSessionDataAccess
    {
        private readonly IMongoDbClient _mongoDbClient;

        public UploadSessionDataAccess(IMongoDbClient mongoDbClient)
        {
            if (mongoDbClient == null)
            {
                throw new ArgumentNullException(nameof(mongoDbClient));
            }

            _mongoDbClient = mongoDbClient;
        }

        public Task SaveAsync(DomainModel.UploadSessons.UploadSession uploadSession)
        {
            if (uploadSession == null)
            {
                throw new NotImplementedException(nameof(uploadSession));
            }

            var database = _mongoDbClient.GetDatabase();
            var collection = database.GetCollection<DomainModel.UploadSessons.UploadSession>("test");

            return collection.InsertOneAsync(uploadSession);
        }
    }
}
