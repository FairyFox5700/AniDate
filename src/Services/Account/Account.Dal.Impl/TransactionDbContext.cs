using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Account.Dal.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Account.Dal.Impl
{
    public class TransactionDbContext  : DbContext,IDbContext
    {
        private IDbContextTransaction _transaction;
        private Guid _transactionId;

        public TransactionDbContext ([NotNull] DbContextOptions options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (_transaction != null)
                return await Task.FromResult(0);

            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<Guid> BeginTransactionAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (_transaction != null)
                return Guid.Empty;

            _transaction = await Database.BeginTransactionAsync(cancellationToken);
            _transactionId = Guid.NewGuid();
            return _transactionId;
        }

        public async Task CommitAsync(Guid transactionId, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_transaction == null || transactionId != _transactionId)
                return;

            try
            {
                await base.SaveChangesAsync(cancellationToken);
                await _transaction.CommitAsync(cancellationToken);
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackAsync(Guid transactionId,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (_transaction == null || transactionId != _transactionId)
                return;
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
        }
    }
}
    
     