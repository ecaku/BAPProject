using System.Threading.Tasks;

namespace BAProjeFront.ApiServices.Interfaces{
    public interface IimageApiService{
        Task<string> GetProductImageById(int id);
    }
}