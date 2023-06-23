using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Service.Application.Services.Interfaces;

public interface IBaseValidationService
{
    Task<bool> ExistsById<TEntity>(int id)
        where TEntity : SimpleDbEntity;
    Task<bool> ExistsById<TEntity>(Guid id)
        where TEntity : ComplexDbEntity;

    Task<bool> ExistsBy<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : DbEntity;
}
