using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ModelArchive.Application.Contracts.Repositories;
using ModelArchive.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelArchive.Persistence
{
    public class Transaction<TResponse> : ITransaction<TResponse>
    {
        private readonly IDatabaseTransaction _dbTransaction;

        public Transaction(IDatabaseTransaction transaction)
        {
            _dbTransaction = transaction;
        }

        public async Task<TResponse> ExecuteInTransaction(Func<Task<TResponse>> action)
        {
            IExecutionStrategy strategy = _dbTransaction.CreateExecutionStrategy();

            TResponse response = await strategy.ExecuteAsync(async () =>
            {
                try
                {
                    await _dbTransaction.StartTransactionAsync();

                    var result = await action();

                    await _dbTransaction.CommitTransactionAsync();

                    return result;
                }
                catch
                {
                    await _dbTransaction.StopTransactionAsync();

                    throw;
                }
            });

            return response;
        }
    }
}
