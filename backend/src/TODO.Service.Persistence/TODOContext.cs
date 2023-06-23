using Todo.Service.Domain.Entities.General;

namespace Todo.Service.Persistence;

public class TodoContext : DbContext, ITodoContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoInitializer).Assembly);

        // Lower Table Names
        modelBuilder.Model.GetEntityTypes()
            .ToList()
            .ForEach(t => t.SetTableName(t.GetTableName().ToLower()));

        // Lower column names
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .ToList()
            .ForEach(p => p.SetColumnName(p.GetColumnName().ToLower()));
    }

    public override int SaveChanges()
    {
        SetDateOnEntities();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetDateOnEntities();

        return base.SaveChangesAsync();
    }

    private void SetDateOnEntities()
    {
        var entries = ChangeTracker
           .Entries()
           .Where(e => e.Entity is ETracker && (
                   e.State == EntityState.Added
                   || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Modified)
            {
                ((ETracker)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Added)
            {
                ((ETracker)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }
        }
    }
}
