using Ninject;
using Ninject.Syntax;
using System;

namespace MyDiary.FileServer.Domain.Models.FactoryPattern
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private IResolutionRoot _resolutionRoot;
        public RepositoryFactory(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }
        public IRepositoryProvider CreateInstance(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            var impl =  _resolutionRoot.Get<IRepositoryProvider>(repository.Type);
            impl.Init(repository);

            return impl;
        }
    }
}
