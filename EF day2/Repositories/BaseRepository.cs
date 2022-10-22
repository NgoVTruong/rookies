using EF_day2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EF_day2.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly ProductManagementContext _context;
        public BaseRepository(ProductManagementContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public T Create(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);

            return true;
        }

        public T? Get(Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? _dbSet.FirstOrDefault() : _dbSet.FirstOrDefault(predicate);

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? _dbSet : _dbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IDataBaseTransaction DatabaseTransaction()
        {
            return new EntityDataBaseTransaction(_context);
        }
    }
}