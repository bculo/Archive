using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelArchive.Application.Contracts.Repositories
{
    public interface ITransaction<TResponse>
    {
        Task<TResponse> ExecuteInTransaction(Func<Task<TResponse>> action);
    }
}
