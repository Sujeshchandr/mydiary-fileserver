using MyDiary.FileServer.DataAccess.Memory.FileVersion.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.DataAccess.Memory.FileVersion
{
    public class FileVersionDataAccess : IFileVersionDataAccess
    {
        public async Task<string> GetNameAsync(string containerName, string fileId, int fileVersionNumber)
        {
            return await Task.Run(() => GetName(containerName, fileId, fileVersionNumber)).ConfigureAwait(false);
        }

        private string GetName(string containerName, string fileId, int fileVersionNumber)
        {
            return containerName + "_" + "files" + fileId + "_" + "versions" + "_" + fileVersionNumber;
        }
    }
}
