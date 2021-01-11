using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.DataAccess.Interfaces
{
    public interface ICartDal:IGenericDal<Cart>
    {
        Task<Cart> GetCartWithProductOfCartByIdAsync(int id);
    }
}
