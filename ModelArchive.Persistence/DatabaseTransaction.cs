using Microsoft.EntityFrameworkCore.Storage;
using ModelArchive.Application.Contracts.Repositories;
using System;
using System.Threading.Tasks;

namespace ModelArchive.Persistence
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private readonly ArchiveDbContext _context;

        public DatabaseTransaction(ArchiveDbContext context)
        {
            _context = context;
        }

        private IDbContextTransaction CurrentTransaction { get; set; }

        /// <summary>
        /// Commit started transaction
        /// </summary>
        /// <param name="transaction">Transaction instance</param>
        /// <returns></returns>
        public async Task CommitTransactionAsync()
        {
            if (CurrentTransaction is null)
                throw new ArgumentNullException(nameof(CurrentTransaction));

            try
            {
                CurrentTransaction.Commit();
            }
            catch
            {
                await CurrentTransaction.RollbackAsync();
            }
        }

        /// <summary>
        /// Create execution strategy
        /// </summary>
        /// <returns></returns>
        public IExecutionStrategy CreateExecutionStrategy()
        {
            return _context.Database.CreateExecutionStrategy();
        }


        /// <summary>
        /// Create IDbContextTransaction
        /// </summary>
        /// <returns></returns>
        public async Task StartTransactionAsync()
        {
            if (CurrentTransaction != null)
                throw new InvalidOperationException($"Transaction with id: {CurrentTransaction.TransactionId} already started");

            CurrentTransaction = await _context.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Clean everything
        /// </summary>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        // To detect redundant calls
        private bool _disposed = false;

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                CurrentTransaction?.Dispose();
                CurrentTransaction = null;
            }

            _disposed = true;
        }
    }
}
