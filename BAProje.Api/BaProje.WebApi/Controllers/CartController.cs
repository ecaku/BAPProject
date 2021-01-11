using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaProje.Business.Interfaces;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace BaProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IProductOfCartService _productOfCartService;
        public CartController(ICartService cartService, IProductService productService,IProductOfCartService productOfCartService)
        {
            _cartService = cartService;
            _productOfCartService = productOfCartService;
            _productService = productService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardWithCustomerId(int id)
        {
            var cart = await _cartService.GetCartWithCustomerIdAsync(id);
            if (cart != null)
            {
                return Ok(cart);
            }
            return NotFound();
            
            
        }
        [HttpPost("[action]")]
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> AddProductToCart(AddProductToCartDto addProductToCartDto)
        {
            var cart = await _cartService.GetCartById(addProductToCartDto.CartId);
            var fullProduct = await _productService.FindByIdAsync(addProductToCartDto.ProductId);
            var addedProductModel = new ProductOfCart {
                ProductName = fullProduct.ProductName,
                Price = fullProduct.Price,
                OrderQuantity = 1,
                CartId = cart.Id,
                RealProductId = fullProduct.Id
            };
            

            await _productOfCartService.AddAsync(addedProductModel);

            return Created("",addedProductModel);



        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            
            await _productOfCartService.RemoveAsync(
                new ProductOfCart{ Id=id });

            return NoContent();
        }
  
    }
}