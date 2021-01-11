using System.Threading.Tasks;
using BAProjeFront.Models;

namespace BAProjeFront.ApiServices.Interfaces{
    public interface ICartService{
        Task<Cart> GetCartAsync(int id);
        Task<ProductOfCart> AddProductToCartAsync(int id);
        Task DeleteProductFromCartAsnc(int id);
    }
}