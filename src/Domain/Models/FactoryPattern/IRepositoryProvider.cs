using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Domain.Models.FactoryPattern
{
    public interface IRepositoryProvider
    {
        string Deposit();

        void Init(IRepository repository);
    }
}
