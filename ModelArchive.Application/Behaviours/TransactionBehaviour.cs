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
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IDatabaseTransaction _context;

        public TransactionBehaviour(IDatabaseTransaction context)
        {
            _context = context;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            IExecutionStrategy strategy = _context.CreateExecutionStrategy();

            TResponse response = await strategy.ExecuteAsync(async () =>
            {
                await _context.StartTransactionAsync();

                var result = await next();

                await _context.CommitTransactionAsync();

                return result;
            });

            return response;
        }
    }
}





















































































