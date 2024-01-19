using AppLight.Core.Entities;
using AppLight.Core.Repositories;
using AppLight.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Data.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly ProjectDbContext _context;

        public GenericRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAysnc(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
        {
            var query = GetQuery(includes);

            return expression is not null ? await query.Where(expression).ToListAsync() : await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAysnc(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
        {
            var query = GetQuery(includes);

            return expression is not null ? await query.Where(expression).FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private IQueryable<TEntity> GetQuery(params string[]? includes)
        {
            var query = Table.AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }
    }

}
