using CleanArquitecture.Domain.Common;

namespace CleanArquitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        //Custom Repositories
        IStreamerRepository StreamerRepository { get; }
        IVideoRepository VideoRepository { get; }

        //Generic Repository
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
