using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.DataAccess.Interfaces
{
    public interface IProductOfCartDal:IGenericDal<ProductOfCart>
    {
        public Task<List<Customer>> GetProductWithCardId(int Id);
    }
}
