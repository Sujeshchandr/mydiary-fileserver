using System;

namespace MyDiary.FileServer.Domain.Models.FactoryPattern
{
    public class RepositoryFTPImplementation : IRepositoryProvider
    {
        public IRepository _repository { get; set; }

        public string Deposit()
        {
            return this._repository.Name;
        }

        public void Init(IRepository repository)
        {
            this._repository = repository;
        }
    }
}
