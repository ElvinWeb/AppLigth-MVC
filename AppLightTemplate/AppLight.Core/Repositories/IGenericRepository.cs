using AppLight.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()  
    {
        public DbSet<TEntity> Table { get;}
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAysnc(Expression<Func<TEntity , bool>>? expression = null , params string[]? includes);
        Task<List<TEntity>> GetAllAysnc(Expression<Func<TEntity , bool>>? expression = null , params string[]? includes);
        Task<int> SaveAsync();
    }
}
