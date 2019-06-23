using System;
using System.Data;
using DataAccess.Core.Entities;

namespace DataAccess.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IReadWriteRepository<User, long> UserRepository { get; }

        void Save();

        ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}