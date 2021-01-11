using BAProje.Entities.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.Business.Interfaces
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<List<Category>> GetAllSortedByNameAsync();
        
        
    }
}
