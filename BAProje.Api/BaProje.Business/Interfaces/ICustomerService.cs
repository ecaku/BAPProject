using BAProje.Entities.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.Business.Interfaces
{
    public interface ICustomerService:IGenericService<Customer>
    {
        Task<Customer> CheckCustomerAsync(CustomerLoginDto customerLoginDto);
        Task<Customer> FindByNameAsync(string userName);
        Task<List<Customer>> GetCustomersWithCart();
        Task<Customer> GetCustomersWithCart(int id);
        


    }
}
