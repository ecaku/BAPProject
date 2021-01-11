using BaProje.Business.Interfaces;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.Business.Concrete
{
    public class ProductManager:GenericManager<Product>,IProductService
    {
        private readonly IGenericDal<Product> _genericDal;
        private readonly IProductDal __productDal;
        
        public ProductManager(IGenericDal<Product> genericDal,IProductDal productDal):base(genericDal)
        {
            _genericDal = genericDal;
            __productDal = productDal;
            
            
        }

        public async Task<List<Product>> GetAllSortedByPostedTimeAsync()
        { 
            return await _genericDal.GetAllAsync(I => I.PostedTime);
        }

        public async Task<List<Product>> GetLastFive()
        {
            return(await __productDal.GetLastFiveAsync());
        }

        public async Task<List<Product>> GetProductsWithCategoryIdAsync(int categoryId)
        {
            return await _genericDal.GetAllAsync(I => I.CategoryId == categoryId);
            
        }
        
        public async Task<List<Product>> SearchProductAsync(string searchKey)
        {
            var searchingProducts = await _genericDal.GetAllAsync
               (I => I.ProductName.Contains(searchKey) || I.ProductDescription.Contains(searchKey)
               || I.Category.CategoryName.Contains(searchKey));
            return searchingProducts;
        }
    }
}
