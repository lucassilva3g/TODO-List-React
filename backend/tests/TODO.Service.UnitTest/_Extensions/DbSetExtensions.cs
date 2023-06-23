using Microsoft.EntityFrameworkCore;

namespace Todo.Service.UnitTest._Extensions;

public static class DbSetExtensions
{
    public static DbSet<T> AsDbSet<T>(this List<T> items)
        where T : class
    {
        return (items ?? new List<T>()).AsQueryable().BuildMockDbSet();
    }
}

