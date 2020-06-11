using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Transfermarkt.WebAPI.Services
{
    public interface IData<T> where T : class
    {
        List<T> Get();
        T GetById(int id);
        T GetLast();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate);
        T GetTByCondition(Expression<Func<T, bool>> predicate);
        T Insert(T entity);
        T Update(T entity);
    }
}
