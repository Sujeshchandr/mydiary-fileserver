using MyDiary.FileServer.Application.Providers.Contract;
using MyDiary.FileServer.Application.Reference;
using MyDiary.FileServer.DataAccess.Memory.FileVersion.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Providers.FileVersion
{
    public sealed class FileVersionNameProvider : StoredObjectNameProvider<FileVersionReference>
    {
        private readonly IFileVersionDataAccess _fileVersionDataAccess;

        private readonly IStoredObjectNameProvider _storedObjectNameProvider;

        public FileVersionNameProvider(IFileVersionDataAccess fileVersionDataAccess, IStoredObjectNameProvider storedObjectNameProvider)
            : base(storedObjectNameProvider)
        {
            if (fileVersionDataAccess == null)
            {
                throw new ArgumentNullException("fileVersionDataAccess");
            }

            _fileVersionDataAccess = fileVersionDataAccess;
            _storedObjectNameProvider = storedObjectNameProvider;
        }

        protected async override Task<string> GetStoredObjectNameAsync(FileVersionReference fileVersionReference)
        {
            if (fileVersionReference == null)
            {
                throw new ArgumentNullException("fileVersionReference");
            }

            return await _fileVersionDataAccess.GetNameAsync(fileVersionReference.ContainerName,
                                                             fileVersionReference.FileId, 
                                                             fileVersionReference.FileVersionNumber).ConfigureAwait(false);
        }
      
    }
}
