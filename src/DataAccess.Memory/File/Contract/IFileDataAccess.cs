using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.DataAccess.Memory.File.Contract
{
    public interface IFileDataAccess
    {
        Task<string> GetNameAsync(string containerName,string fileId);
    }
}
