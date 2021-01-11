using BaProje.DataAccess.Interfaces;
using BaProje.DataAccess.Concrete.EFRepository.Context;
using BAProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BaProje.DataAccess.Concrete.EFRepository.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new BAP_Context();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            using var context = new BAP_Context();
            return await context.FindAsync<TEntity>(id);
            
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new BAP_Context();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new BAP_Context();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new BAP_Context();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllASync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new BAP_Context();
            return await context.Set<TEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new BAP_Context();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using var context = new BAP_Context();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new BAP_Context();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
