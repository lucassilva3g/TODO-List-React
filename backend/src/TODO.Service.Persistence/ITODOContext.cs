using System.Diagnostics.CodeAnalysis;

[assembly: ExcludeFromCodeCoverage]
namespace Todo.Service.Persistence;

public interface ITodoContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
