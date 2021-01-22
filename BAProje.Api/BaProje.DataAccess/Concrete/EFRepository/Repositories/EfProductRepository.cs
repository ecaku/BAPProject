using BaProje.DataAccess.Concrete.EFRepository.Context;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.DataAccess.Concrete.EFRepository.Repositories
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductDal
    {
        private readonly BAP_Context _context;
        public EfProductRepository(BAP_Context context):base(context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetLastFiveAsync()
        {
            {
                
                return await _context.Product.OrderByDescending(I => I.PostedTime).Take(3).ToListAsync();
            }
        }
    }
}
