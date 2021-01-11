using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using BaProje.Business.Concrete;
using BaProje.Business.Interfaces;
using BaProje.WebApi.CustomFilters;
using BAProje.Entities.Concrete;
using BAProje.Entities.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<ProductListDto>>(await _productService.GetAllSortedByPostedTimeAsync()));
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<ProductListDto>(await _productService.FindByIdAsync(id)));
        }
        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm]ProductAddDto productAddDto)
        {
            var uploadModel = await UploadImageFileAsync(productAddDto.Image,"image/jpeg");
            if (uploadModel.UploadState == UploadState.Success)
            {
                productAddDto.ImagePath = uploadModel.NewName;
                await _productService.AddAsync(_mapper.Map<Product>(productAddDto));
                return Created("", productAddDto);
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                await _productService.AddAsync(_mapper.Map<Product>(productAddDto));
                return Created("", productAddDto);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }
        [HttpPut("{id}")]
        [Authorize(Roles ="Admin")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Update(int id,[FromForm]ProductUpdateDto productUpdateDto)
        {
            if (id != productUpdateDto.Id)
                return BadRequest("geçersiz id");

            else if (id == productUpdateDto.Id)
            {
                var uploadModel = await UploadImageFileAsync(productUpdateDto.Image, "image/jpeg");
                if (uploadModel.UploadState == UploadState.Success)
                {
                    var updatedProduct = await _productService.FindByIdAsync(productUpdateDto.Id);

                    var oldProduct = await _productService.FindByIdAsync(productUpdateDto.Id);

                    if (productUpdateDto.ProductName == null)
                        updatedProduct.ProductName = oldProduct.ProductName;
                    else
                        updatedProduct.ProductName = productUpdateDto.ProductName;

                    if (productUpdateDto.ProductDescription == null)
                        updatedProduct.ProductDescription = oldProduct.ProductDescription;
                    else
                        updatedProduct.ProductDescription = productUpdateDto.ProductDescription;

                    if (productUpdateDto.Price == 0)
                        updatedProduct.Price = oldProduct.Price;
                    else
                        updatedProduct.Price = productUpdateDto.Price;

                    if (productUpdateDto.StockQuantity == 0)
                        updatedProduct.StockQuantity = oldProduct.StockQuantity;
                    else
                        updatedProduct.StockQuantity = productUpdateDto.StockQuantity;


                    updatedProduct.ImagePath = uploadModel.NewName;

                    await _productService.UpdateAsync(updatedProduct);

                    return NoContent();
                }
                else if (uploadModel.UploadState == UploadState.NotExist)
                {
                    var updatedProduct = await _productService.FindByIdAsync(productUpdateDto.Id);
                    updatedProduct.Price = productUpdateDto.Price;
                    updatedProduct.ProductDescription = productUpdateDto.ProductDescription;
                    updatedProduct.ProductName = productUpdateDto.ProductName;
                    updatedProduct.StockQuantity = productUpdateDto.StockQuantity;

                    await _productService.UpdateAsync(updatedProduct);

                    return NoContent();
                }
                else
                {
                    return BadRequest(uploadModel.ErrorMessage);
                }
            }
            else
            {
                return null;
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.RemoveAsync(await _productService.FindByIdAsync(id));
            return NoContent();

        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductsWithCategoryId(int Id)
        {
            
            return Ok(await _productService.GetProductsWithCategoryIdAsync(Id));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLastFiveProduct()
        {
            var products=await _productService.GetLastFive();
            return Ok(products);
        }
        [HttpGet("[action]/{searchKey}")]
        public async Task<IActionResult> GetProductsWithSearch(string searchKey)
        {
            var products = await _productService.SearchProductAsync(searchKey);
            return Ok(products);
        }


    }
}