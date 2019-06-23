using System;
using System.Data;
using System.Data.Entity;
using DataAccess.Core.Interfaces;


namespace DataAccess.Core.Utilities
{
    public class CustomDbContextTransaction : ITransaction
    {
        private readonly DbContextTransaction transaction;

        private bool isDisposed;

        public CustomDbContextTransaction(DbContext context, IsolationLevel isolatedLevel)
        {
            transaction = context.Database.BeginTransaction(isolatedLevel);
            isDisposed = false;
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
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
                    transaction.Dispose();
                }
            }

            isDisposed = true;
        }
    }
}
