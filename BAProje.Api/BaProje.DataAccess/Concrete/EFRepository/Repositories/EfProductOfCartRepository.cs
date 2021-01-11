using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.DataAccess.Concrete.EFRepository.Repositories
{
    public class EfProductOfCartRepository : EfGenericRepository<ProductOfCart>, IProductOfCartDal
    {
        public Task<List<Customer>> GetProductWithCardId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
