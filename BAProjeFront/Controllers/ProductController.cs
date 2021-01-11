using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.Controllers{
    [Route("[controller]/[action]")]

    public class ProductController:Controller{
        

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService=productService;
        }
        public async Task<IActionResult> Index(string searchS){

            if(!string.IsNullOrWhiteSpace(searchS)){
                 ViewBag.SearchString=searchS;
                return View(await _productService.GetProductsBySearchAsync(searchS));
            }
          
            return View(await _productService.GetAllAsync());
        }
        
        public async Task<IActionResult> ProductDetails(int id){
            return View(await _productService.GetProductByIdAsync(id));
        }
        public async Task<IActionResult> GetProductsByCategory(int categoryId){
            return View(await _productService.GetProductsByCategoryIdAsync(categoryId));
            
        }
        // [HttpGet("{searchString}")]
        // public async Task<IActionResult> GetProductsBySearch(string searchString){
            
        //     return null;
        // }
    }
}