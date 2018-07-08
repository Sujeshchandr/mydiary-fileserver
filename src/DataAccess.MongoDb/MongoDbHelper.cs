using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiary.FileServer.DataAccess.MongoDb
{
    public class MongoDbClient : IMongoDbClient
    {
        private string _connectionString { get; set; }

        private string _databasename { get; set; }

        public MongoDbClient(string connectionString, string databaseName)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            if (databaseName == null)
            {
                throw new ArgumentNullException(nameof(databaseName));
            }

            _connectionString = connectionString;

            _databasename = databaseName;
        }

        public IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(_connectionString);
            return client.GetDatabase(_databasename);
        }
    }
}
