using System.Diagnostics.CodeAnalysis;

[assembly: ExcludeFromCodeCoverage]
namespace TODO.Service.Persistence;


public interface ICredMouraContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
