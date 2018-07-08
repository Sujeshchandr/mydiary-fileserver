using MyDiary.FileServer.Application.Providers.Contract;
using MyDiary.FileServer.DataAccess.Memory.UploadSession.Contract;
using MyDiary.FileServer.Domain.Models.UploadSessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Providers.UploadSession
{
    public sealed class UploadSessionNameProvider : StoredObjectNameProvider<UploadSessionReference>
    {
        private readonly IUploadSessionDataAccess _uploadSessionDataAccess;

        private readonly IStoredObjectNameProvider _storedObjectNameProvider;

        public UploadSessionNameProvider(IUploadSessionDataAccess uploadSessionDataAccess, 
                                         IStoredObjectNameProvider storedObjectNameProvider) : base(storedObjectNameProvider)
        {
            if (uploadSessionDataAccess == null)
            {
                throw new ArgumentNullException("uploadSessionDataAccess");
            }

            _uploadSessionDataAccess = uploadSessionDataAccess;
            _storedObjectNameProvider = storedObjectNameProvider;
        }

        protected async override Task<string> GetStoredObjectNameAsync(UploadSessionReference uploadSessionReference)
        {
            if (uploadSessionReference == null)
            {
                throw new ArgumentNullException("uploadSessionReference");
            }
            return await _uploadSessionDataAccess.GetNameAsync(uploadSessionReference.ContainerName, uploadSessionReference.UploadSessionId).ConfigureAwait(false);
        }
    }
}
