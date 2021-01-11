

using System.Collections.Generic;
using System.Threading.Tasks;
using BAProjeFront.Models;

namespace BAProjeFront.ApiServices.Interfaces{
    public interface IProductService{
        Task<List<ProductListModel>> GetAllAsync();
        Task<ProductListModel> GetProductByIdAsync(int id);
        Task<List<ProductListModel>> GetProductsByCategoryIdAsync(int categoryId);
        Task<ProductListModel> UpdateProductAsync(ProductListModel productListModel1);
        Task AddAsync(ProductListModel productListModel);
        Task DeleteAsync(int id);
        Task<List<ProductListModel>> GetLastFiveAsync();
        Task<List<ProductListModel>> GetProductsBySearchAsync(string searchString);
    }
}