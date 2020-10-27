using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelArchive.Application.Contracts.Repositories
{
    public interface IDatabaseTransaction : IDisposable
    {
        IExecutionStrategy CreateExecutionStrategy();
        Task StartTransactionAsync();
        Task CommitTransactionAsync();
    }
}
