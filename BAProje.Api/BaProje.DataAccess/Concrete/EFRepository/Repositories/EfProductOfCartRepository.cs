using BaProje.DataAccess.Concrete.EFRepository.Context;
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
        private readonly BAP_Context _context;
        public EfProductOfCartRepository(BAP_Context context):base(context)
        {
            _context = context;
        }

        public Task<List<Customer>> GetProductWithCardId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
