using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;
using BAProjeFront.Filters;
using BAProjeFront.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.Areas.Admin.Controllers{
    [Area("Admin")]
    public class ProductController:Controller{
        
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService=productService;
        }
        public async Task<IActionResult> GetAllProducts(){
            var products=await _productService.GetAllAsync();
            return View(products);
        }
        public async Task<IActionResult> DetailProduct(int id){
            var product=await _productService.GetProductByIdAsync(id);
            return View(product);
        }
        [HttpPost]
        [AdminAuthorize]
        public async Task<IActionResult> UpdateProduct(ProductListModel productListModel){
            
            var updatedProduct= await _productService.UpdateProductAsync(productListModel);
            
            return RedirectToAction("GetAllProducts");
            
            
        }
        
        public IActionResult Create(){
            return View(new ProductListModel());
        }
        
        [HttpPost]
        [AdminAuthorize]
        public async Task<IActionResult> Create(ProductListModel productListModel){
            if(ModelState.IsValid){
                await _productService.AddAsync(productListModel);
                return RedirectToAction($"DetailProduct({productListModel.Id})");
            }
            return View();
        }
        [AdminAuthorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            await _productService.DeleteAsync(id);
            return RedirectToAction("GetAllProducts");
        }
            
        
    }
}