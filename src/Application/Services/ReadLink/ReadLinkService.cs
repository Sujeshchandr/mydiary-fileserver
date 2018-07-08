using MyDiary.FileServer.Application.Providers.Contract;
using MyDiary.FileServer.Application.Services.ReadLink.Contract;
using MyDiary.FileServer.Domain.Models.Core;
using MyDiary.FileServer.Domain.Models.UploadSessons;
using NLog;
using System;
using System.Threading.Tasks;
using DomainModel = MyDiary.FileServer.Domain.Models;
using Application = MyDiary.FileServer.Application;
using MyDiary.FileServer.DataAccess.MongoDb.UploadSession.Contracts;

namespace MyDiary.FileServer.Application.Services.ReadLink
{
    public class ReadLinkService : IReadLinkService
    {
        ////read-only(getter only) properties
        public string abc => string.Join(",", abc, abc);

        private readonly IStoredObjectNameProvider _storedObjectNameProvider;

        private readonly ILogger _logger;

        private readonly DataAccess.MongoDb.UploadSession.Contracts.IUploadSessionDataAccess _uploadSessionMOngoDbDataAcess;

        //// public bool IsDisposed
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public event EventHandler Disposed;

        public ReadLinkService(
            ILogger logger,
            IStoredObjectNameProvider uploadSessionNameProvider,
            IUploadSessionDataAccess uploadSessionMOngoDbDataAcess)
        {
            if (uploadSessionNameProvider == null)
            {
                throw new ArgumentNullException(nameof(uploadSessionNameProvider));
            }

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (uploadSessionMOngoDbDataAcess == null)
            {
                throw new ArgumentNullException(nameof(uploadSessionMOngoDbDataAcess));
            }

            _storedObjectNameProvider = uploadSessionNameProvider;
            _logger = logger;
            _uploadSessionMOngoDbDataAcess = uploadSessionMOngoDbDataAcess;

            ////Disposed += OnDisposed;

            //// _logger.Info("ReadLinkService object created");
        }

        ////private void OnDisposed(object sender, EventArgs e)
        ////{
        ////    _logger.Info("ReadLinkService OnDisposed ==> started");
        ////    EventHandler disposed = Disposed;
        ////    if (disposed != null)
        ////    {
        ////        _logger.Info("ReadLinkService OnDisposed ==> end");
        ////        disposed(this, e);
        ////    }
        ////}

        public async Task<string> GetUploadSessionNameAsync(string containerName, string uploadSessionId)
        {
           var a=  GetNullableString("sss");
            var b = GetNullableString(null);

            var uploadSessionReference = new UploadSessionReference()
            {
                ContainerName = containerName,
                UploadSessionId = uploadSessionId
            };

            var uploadSession = new DomainModel.UploadSessons.UploadSession()
            {
                Id = new Guid().ToString(),
                Length = 3000,
                Name = "Figue 1.jpeg"
            };

            await _uploadSessionMOngoDbDataAcess.SaveAsync(uploadSession).ConfigureAwait(false);

            return await _storedObjectNameProvider.GetNameAsync(uploadSessionReference).ConfigureAwait(false);
        }

        public async Task<string> GetFileNameAsync(string containerName, string fileId)
        {
            var fileReference = new FileReference()
            {
                ContainerName = containerName,
                FileId = fileId
            };

            return await _storedObjectNameProvider.GetNameAsync(fileReference).ConfigureAwait(false);
        }

        public async Task<string> GetFileVersionNameAsync(string containerName, string fileId, int versionNumber)
        {
            var fileVersionReference = new Application.Reference.FileVersionReference()
            {
                ContainerName = containerName,
                FileId = fileId,
                FileVersionNumber = versionNumber
            };

            return await _storedObjectNameProvider.GetNameAsync(fileVersionReference).ConfigureAwait(false);
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        private static string GetNullableString(string value)
        {
             return value?.Substring(1).ToString();
        }

        public override string ToString() => base.ToString();       
    }

}

