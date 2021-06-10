using LeaveManagement.ApplicationCore.Interfaces.Repositories;
using LeaveManagement.Infrastructure.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Infrastructure.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LeaveManagementDbContext _dbContext;
        private DbSet<T> dbSet;
        public Repository(LeaveManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }
        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<T> Find(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, string[] includes = null)
        {
            var query = GetQuery(includes);
            return await query.Where(filter).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<T>> GetAll(string[] includes = null, int count =3)
        {
            var query = GetQuery(includes);
            return await query.Take(count).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, string[] includes = null)
        {
            var query = GetQuery(includes);
            return await query.Where(filter).Take(20).ToListAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        private IQueryable<T> GetQuery(string[] includes)
        {
            IQueryable<T> query = dbSet;
            if (includes != null)
            {
                foreach (var child in includes)
                {
                    query = query.Include(child);
                }
            }
            return query;
        }
    }
}
