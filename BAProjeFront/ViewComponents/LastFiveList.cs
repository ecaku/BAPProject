using BAProjeFront.ApiServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.ViewComponents{
    public class LastFiveList:ViewComponent{

        private readonly IProductService _productService;

        public LastFiveList(IProductService productService)
        {
            _productService=productService;
        }
        public IViewComponentResult Invoke(){
            var products=_productService.GetLastFiveAsync().Result;
            return View(products);
        }
    }
}