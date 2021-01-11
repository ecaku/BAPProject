using System.Net.Http;
using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;
using BAProjeFront.Filters;
using BAProjeFront.Models;
using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.Controllers{
    [Route("[controller]/[action]")]
    public class CartController:Controller{

        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService=cartService;
            
        }
        [JwtActionAuthorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> AddProductToCart(int id)
        {
            await _cartService.AddProductToCartAsync(id);
            return RedirectToAction("accountInfo","account",new{@area=""});
        }
        [JwtActionAuthorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            await _cartService.DeleteProductFromCartAsnc(id);
            return RedirectToAction("accountInfo","account",new{@area=""});      
        }
    }
}