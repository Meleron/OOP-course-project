using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Database
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetList();
        T Search(string item);
        void Create(T item);
        void Update(T item);
    }
}
