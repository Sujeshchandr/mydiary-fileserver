using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.DataAccess.Memory.FileVersion.Contract
{
    public interface IFileVersionDataAccess
    {
        Task<string> GetNameAsync(string containerName, string fileId, int fileVersionNumber);
    }
}
