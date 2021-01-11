using BAProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.Business.Interfaces
{
    public interface IGenericService<TEntity> where TEntity:class,ITable,new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
