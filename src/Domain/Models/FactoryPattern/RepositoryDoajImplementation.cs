using System;

namespace MyDiary.FileServer.Domain.Models.FactoryPattern
{
    public class RepositoryDoajImplementation 
    {

        public RepositoryDoajImplementation()
        {

        }

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
            return;
        }
    }
}
