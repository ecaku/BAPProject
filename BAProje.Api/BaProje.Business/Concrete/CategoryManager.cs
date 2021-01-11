using BaProje.Business.Interfaces;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.Business.Concrete
{
    public class CategoryManager:GenericManager<Category>,ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;
        
        
        public CategoryManager(IGenericDal<Category> genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }

       


        public async Task<List<Category>> GetAllSortedByNameAsync()
        {
            return await _genericDal.GetAllAsync(I => I.CategoryName);
        }

    }
}
