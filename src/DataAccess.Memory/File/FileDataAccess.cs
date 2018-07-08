using MyDiary.FileServer.DataAccess.Memory.File.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.DataAccess.Memory.File
{
    public class FileDataAccess : IFileDataAccess
    {
        public async Task<string> GetNameAsync(string containerName, string fileId)
        {
            return await Task.Run(() => GetName(containerName, fileId)).ConfigureAwait(false);
        }

        private string GetName(string containerName, string fileId)
        {
            return containerName  + "_"+  "files" +"_" + fileId;
        }
    }
}
