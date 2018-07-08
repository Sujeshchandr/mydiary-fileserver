using MyDiary.FileServer.Application.Providers.Contract;
using MyDiary.FileServer.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Application.Providers
{
    public abstract class StoredObjectNameProvider<TReference> : IStoredObjectNameProvider  where TReference : StoredObjectReference
    {
        private IStoredObjectNameProvider _next;

        public StoredObjectNameProvider(IStoredObjectNameProvider next) 
        {
            _next = next;
        }

        private IStoredObjectNameProvider Next
        {
            get
            {
                return _next;
            }
        }
        
        public Task<string> GetNameAsync(StoredObjectReference storedObjectReference)
        {
            if(!CanHandle(storedObjectReference))
            {
                return Next.GetNameAsync(storedObjectReference);
            }
            return GetStoredObjectNameAsync(storedObjectReference as TReference);
        }

        protected virtual bool CanHandle(StoredObjectReference storedObjectReference)
        {
            return storedObjectReference is TReference;
        }

        protected abstract Task<string> GetStoredObjectNameAsync(TReference storedObjectReference);
    }
}
