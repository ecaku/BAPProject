using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.Business.Interfaces
{
    public interface ICartService:IGenericService<Cart>
    {
        
        Task<Cart> GetCartWithCustomerIdAsync(int CustomerId);
        Task<Cart> GetCartById(int CartId);


    }
}
