using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaProje.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ImagesController : ControllerBase
    {
        private readonly IProductService _productService;

        public ImagesController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductImageById(int id)
        {
            var product=await _productService.FindByIdAsync(id);
            if (string.IsNullOrWhiteSpace(product.ImagePath))
                return NotFound("resim dosyası yok");
            

            return File($"/img/{product.ImagePath}","image/jpeg");
        }

    }
}