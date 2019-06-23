using System;
using System.Data;
using System.Diagnostics;
using DataAccess.Context.Repositories;
using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using DataAccess.Core.Utilities;

namespace DataAccess.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private CustomContext context;

        private bool isDisposed;
        
        private IReadWriteRepository<User, long> userRepository;
       
        public UnitOfWork(CustomContext context)
        {
            this.context = context;

            isDisposed = false;

            SetDatabaseLog();
        }

        public UnitOfWork()
        {
            context = new CustomContext();

            isDisposed = false;

            SetDatabaseLog();
        }

      
        public IReadWriteRepository<User, long> UserRepository => userRepository ?? (userRepository = new BaseReadWriteRepository<User, long>(context));


        public void Save()
        {
            context.SaveChanges();
        }

        public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return new CustomDbContextTransaction(context, isolationLevel);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    context.Dispose();
                    context = null;
                }
            }

            isDisposed = true;
        }

        private void SetDatabaseLog()
        {
#if DEBUG
            context.Database.Log = x => Debug.Write(x);
#endif
        }
    }
}