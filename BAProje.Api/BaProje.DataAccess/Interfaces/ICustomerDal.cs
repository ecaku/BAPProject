using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.DataAccess.Interfaces
{
    public interface ICustomerDal : IGenericDal<Customer>
    {
        Task<List<Customer>> GetCustomersWithCard();
        Task<Customer> GetCustomersWithCard(int id);
        Task<Customer> FindByNameAsync(string name);
    }
}