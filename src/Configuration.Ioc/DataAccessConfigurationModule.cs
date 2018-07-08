using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Ioc
{
    public class DataAccessConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MyDiary.FileServer.DataAccess.MongoDb.UploadSession.Contracts.IUploadSessionDataAccess>().To<MyDiary.FileServer.DataAccess.MongoDb.UploadSession.UploadSessionDataAccess>().InSingletonScope();
            Bind<MyDiary.FileServer.DataAccess.Memory.UploadSession.Contract.IUploadSessionDataAccess>().To<MyDiary.FileServer.DataAccess.Memory.UploadSession.UploadSessionDataAccess>().InSingletonScope();
            Bind<MyDiary.FileServer.DataAccess.Memory.FileVersion.Contract.IFileVersionDataAccess>().To<MyDiary.FileServer.DataAccess.Memory.FileVersion.FileVersionDataAccess>().InSingletonScope();
            Bind<MyDiary.FileServer.DataAccess.Memory.File.Contract.IFileDataAccess>().To<MyDiary.FileServer.DataAccess.Memory.File.FileDataAccess>().InSingletonScope();
            Bind<MyDiary.FileServer.MyDiary.FileServer.DataAccess.MongoDb.IMongoDbClient>().ToMethod(context => new MyDiary.FileServer.MyDiary.FileServer.DataAccess.MongoDb.MongoDbClient("mongodb://localhost:27017", "test")).InSingletonScope();
        }
    }
}
