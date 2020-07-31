using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class Data<T> : IData<T> where T : class
    {
        protected readonly FootballAssociationDbContext _context;
        private readonly DbSet<T> entities;

        public Data(FootballAssociationDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public List<T> Get()
        {
            return entities.AsNoTracking().ToList();
        }
        public T GetById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            return entity;
        }
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate)
        {
            return entities.AsNoTracking().Where(predicate);
        }
        public T GetTByCondition(Expression<Func<T, bool>> predicate)
        {
            var entity = entities.AsNoTracking().FirstOrDefault(predicate);
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            return entity;
        }
        public T GetLast()
        {
            return _context.Set<T>().LastOrDefault();
        }
        public T Insert(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Entity");
            }

            var x = entities.Add(obj);
            _context.SaveChanges();
            return x.Entity;
        }
        public T Update(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Entity");
            }

            _context.Attach(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return obj;
        }
    }
}
