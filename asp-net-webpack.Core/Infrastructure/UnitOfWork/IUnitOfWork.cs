using System;
using System.Data;

namespace asp_net_webpack.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection IDbConnection { get; }
        IDbTransaction IDbTransaction { get; }
        void Commit();
    }
}
