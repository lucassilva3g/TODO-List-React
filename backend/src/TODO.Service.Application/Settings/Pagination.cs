using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Service.Application.Settings;

public static class Pagination
{
    private static (int skip, int take) CalculateOffset(PageRequest pageRequest)
    {
        int skip = (pageRequest.Number - 1) * pageRequest.Limit;
        return (skip, pageRequest.Limit);
    }

    private static List<TEntity> PaginateEntity<TEntity>(IQueryable<TEntity> query, PageRequest pageRequest)
    {
        var (skip, take) = CalculateOffset(pageRequest);

        return query
            .Skip(skip)
            .Take(take)
            .ToList();
    }

    public static async Task<PageResponse<TEntity>> Paginate<TEntity>(IQueryable<TEntity> query, PageRequest pageRequest)
    {
        var totalItens = await query.CountAsync();

        var paginatedResult = PaginateEntity(query, pageRequest);

        var retorno = PageResponse<TEntity>.For(paginatedResult, pageRequest, totalItens);

        return retorno;
    }
}
