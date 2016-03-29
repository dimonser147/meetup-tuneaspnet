using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPD.DAL
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
