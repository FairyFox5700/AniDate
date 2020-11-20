using System;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Dal.Abstract
{
    public interface IDbContext
    {
        Task<Guid> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(Guid transactionId, CancellationToken cancellationToken = default);
        Task RollbackAsync(Guid transactionId, CancellationToken cancellationToken = default);
    }
}