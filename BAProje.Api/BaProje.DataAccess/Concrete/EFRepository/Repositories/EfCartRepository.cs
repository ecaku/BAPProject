using BaProje.DataAccess.Concrete.EFRepository.Context;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.DataAccess.Concrete.EFRepository.Repositories
{
    public class EfCartRepository:EfGenericRepository<Cart>,ICartDal
    {
        private readonly BAP_Context _context;
        public EfCartRepository(BAP_Context context):base(context)
        {
            _context = context;
        }
        public async Task<Cart> GetCartWithProductOfCartByIdAsync(int id)
        {
            
            var cart = await _context.Cart.Where(I => I.Id == id).Include(I => I.ProductOfCart).FirstOrDefaultAsync();
            return cart;
        }
    }
}
