using System.Collections.Generic;
using System.Threading.Tasks;
using BAProjeFront.Models;

namespace BAProjeFront.ApiServices.Interfaces{
    public interface ICategoryService{
        Task<List<CategoryListModel>> GetAllAsync();
        
    }
}