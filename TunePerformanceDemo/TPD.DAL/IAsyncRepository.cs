using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DAL
{
    public interface IAsyncRepository<T> : IRepository<T>
        where T : class
    {
        Task<T> GetByIdAsync(int id);
    }
}
