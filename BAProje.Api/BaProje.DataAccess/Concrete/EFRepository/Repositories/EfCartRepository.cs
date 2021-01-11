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
        public async Task<Cart> GetCartWithProductOfCartByIdAsync(int id)
        {
            using var context = new BAP_Context();
            var cart = await context.Cart.Where(I => I.Id == id).Include(I => I.ProductOfCart).FirstOrDefaultAsync();
            return cart;
        }
    }
}
