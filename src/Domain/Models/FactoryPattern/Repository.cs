using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.FileServer.Domain.Models.FactoryPattern
{
    public class Repository : IRepository
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
