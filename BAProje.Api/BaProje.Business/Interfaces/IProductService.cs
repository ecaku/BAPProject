using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.Business.Interfaces
{
    public interface IProductService:IGenericService<Product>
    {
        Task<List<Product>> GetAllSortedByPostedTimeAsync();
        Task<List<Product>> GetProductsWithCategoryIdAsync(int categoryId);
        Task<List<Product>> SearchProductAsync(string searchKey);
        Task<List<Product>> GetLastFive();
    }
}
