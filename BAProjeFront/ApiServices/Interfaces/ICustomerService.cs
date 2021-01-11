using System.Collections.Generic;
using System.Threading.Tasks;
using BAProjeFront.Models;

namespace BAProjeFront.ApiServices.Interfaces{
    public interface ICustomerService{
        Task<List<CustomerViewModel>> GetAllCustomersAsync();
        Task<CustomerViewModel> GetCustomerAsync(int id);
    }
}