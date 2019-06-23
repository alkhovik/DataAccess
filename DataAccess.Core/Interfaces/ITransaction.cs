using System;

namespace DataAccess.Core.Interfaces
{
    public interface ITransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
