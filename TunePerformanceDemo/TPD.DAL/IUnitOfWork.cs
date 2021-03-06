﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        Task<int> CommitAsync();
        void Rollback();
    }
}
