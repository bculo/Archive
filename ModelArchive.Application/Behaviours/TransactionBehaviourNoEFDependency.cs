using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ModelArchive.Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Application.Behaviours
{
    /// <summary>
    /// Filter which is responsible for transaction behaviour of application
    /// </summary>
    /// <typeparam name="TRequest">TRequest is command or query</typeparam>
    /// <typeparam name="TResponse">TResonse type dependes on TRequest... We dont care here about Response type</typeparam>
    public class TransactionBehaviourNoEFDependency<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ITransaction<TResponse> _transaction;

        public RequestHandlerDelegate<TResponse> Next { get; set; }

        public TransactionBehaviourNoEFDependency(ITransaction<TResponse> transaction)
        {
            _transaction = transaction;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Next = next;

            var response = await _transaction.ExecuteInTransaction(Execute);

            return response;
        }

        public async Task<TResponse> Execute()
        {
            return await Next();
        }
    }
}





















































































