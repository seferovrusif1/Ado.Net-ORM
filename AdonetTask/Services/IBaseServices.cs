using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdonetTask.Services
{
    internal interface IBaseServices<T>
    {
       
            ICollection<T> GetAll();
            T GetById(int id);
             int Create(T data);
        }
}
