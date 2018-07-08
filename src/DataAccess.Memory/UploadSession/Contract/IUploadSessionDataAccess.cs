using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.DataAccess.Memory.UploadSession.Contract
{
    public interface IUploadSessionDataAccess
    {
        Task<string> GetNameAsync(string containerName, string id);
    }
}
