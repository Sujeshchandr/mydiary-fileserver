using MyDiary.FileServer.Application.Reference;
using MyDiary.FileServer.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Providers.Contract
{
    public interface IStoredObjectNameProvider
    {
        Task<string> GetNameAsync(StoredObjectReference storedObjectReference); 
    }
}
