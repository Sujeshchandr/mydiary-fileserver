using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiary.FileServer.DataAccess.MongoDb
{
    public interface IMongoDbClient
    {
        IMongoDatabase GetDatabase();
    }
}
