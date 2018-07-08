using MyDiary.FileServer.Application.Providers.Contract;
using MyDiary.FileServer.Application.Reference;
using MyDiary.FileServer.DataAccess.Memory.File.Contract;
using MyDiary.FileServer.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Providers.File
{
    public sealed class FileNameProvider : StoredObjectNameProvider<FileReference>
    {
        private readonly IStoredObjectNameProvider _storedObjectNameProvider;

        private readonly IFileDataAccess _fileDataAccess;

        public FileNameProvider(IFileDataAccess fileDataAccess, IStoredObjectNameProvider storedObjectNameProvider) 
               : base(storedObjectNameProvider)
        {
            if (fileDataAccess == null)
            {
                throw new ArgumentNullException("fileDataAccess");
            }

            _fileDataAccess = fileDataAccess;
            _storedObjectNameProvider = storedObjectNameProvider;
        }

        protected async override Task<string> GetStoredObjectNameAsync(FileReference fileReference)
        {
            if (fileReference == null)
            {
                throw new ArgumentNullException("fileVersionReference");
            }

            return await _fileDataAccess.GetNameAsync(fileReference.ContainerName, fileReference.FileId).ConfigureAwait(false);
        }
    }
}
