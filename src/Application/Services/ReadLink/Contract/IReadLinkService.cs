using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDiary.FileServer.Domain.Models.ReadLinks;

namespace MyDiary.FileServer.Application.Services.ReadLink.Contract
{
    public interface IReadLinkService
    {
        Task<string> GetUploadSessionNameAsync(string containerName, string uploadSessionId);

        Task<string> GetFileNameAsync(string containerName, string fileId);

        Task<string> GetFileVersionNameAsync(string containerName, string fileId, int versionNumber);
    }
}
