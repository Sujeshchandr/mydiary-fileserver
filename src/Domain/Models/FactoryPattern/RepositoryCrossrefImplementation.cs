using System;

namespace MyDiary.FileServer.Domain.Models.FactoryPattern
{
    public class RepositoryCrossrefImplementation 
    {
        public IRepository repository
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Deposit()
        {
            throw new NotImplementedException();
        }
    }
}
