using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo.Service.Persistence.EntityConfigurations;

public class TodoItemConfig
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.IsDone)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.DueDate)
            .IsRequired(false);

        builder.Property(x => x.Active).HasDefaultValue(true);

        builder.HasQueryFilter(x => x.Active);
    }   
}
