using MyDiary.FileServer.DataAccess.Memory.UploadSession.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.DataAccess.Memory.UploadSession
{
    public class UploadSessionDataAccess : IUploadSessionDataAccess
    {
        public async Task<string> GetNameAsync(string containerName, string uploadSessionId)
        {
            return await Task.Run(() => GetName(containerName,uploadSessionId)).ConfigureAwait(false);
        }

        private string GetName(string containerName, string id)
        {
            return containerName + "_"+ "uploadSession"+ "_" + id;
        }
    }
}
