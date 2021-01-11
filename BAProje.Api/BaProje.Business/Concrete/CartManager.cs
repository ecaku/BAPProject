using BaProje.Business.Interfaces;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using DTO;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.Business.Concrete
{
    public class CartManager:GenericManager<Cart>,ICartService
    {
        private readonly IGenericDal<Cart> _genericDal;
        
        public CartManager(IGenericDal<Cart> genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }

        

        public async Task<Cart> GetCartWithCustomerIdAsync(int CustomerId)
        {
            return (await _genericDal.GetAsync(I => I.CustomerId == CustomerId));
        }
        public async Task<Cart> GetCartById(int CartId)
        {
            var cart = await _genericDal.GetAsync(I => I.Id == CartId);
            return cart;

        }
        
        
    }
}
