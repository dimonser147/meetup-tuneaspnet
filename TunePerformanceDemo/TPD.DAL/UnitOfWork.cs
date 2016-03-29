using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DAL
{
    public abstract class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected TunePerformanceDemoEntities _context;

        public UnitOfWork(TunePerformanceDemoEntities context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
