using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;
using BAProjeFront.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Web;

namespace BAProjeFront.ApiServices.Concrete{
    public class ProductManager : IProductService
    {   
        
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductManager(HttpClient httpClient,IHttpContextAccessor httpContextAccessor)
        {
            
            _httpClient=httpClient;
            
            _httpClient.BaseAddress=new Uri("http://localhost:51061/api/products/");
            _httpContextAccessor=httpContextAccessor;
        }
        public async Task<List<ProductListModel>> GetAllAsync()
        {
            var responseMessage=await _httpClient.GetAsync("");
            if(responseMessage.IsSuccessStatusCode){
                return JsonConvert.DeserializeObject<List<ProductListModel>>(await responseMessage.Content.ReadAsStringAsync());
                
            }
            else{
                return null;
            }
        }

        public async  Task<ProductListModel> GetProductByIdAsync(int id)
        {
            
            var responseMessage=await _httpClient.GetAsync($"{id}");
            if(responseMessage.IsSuccessStatusCode){
                return JsonConvert.DeserializeObject<ProductListModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            else
                return null;
        }

        public async Task<List<ProductListModel>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var responseMessage=await _httpClient.GetAsync($"GetProductsWithCategoryId/{categoryId}");
            if(responseMessage.IsSuccessStatusCode){
                return JsonConvert.DeserializeObject<List<ProductListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
            
        }

        
        public async Task<ProductListModel> UpdateProductAsync(ProductListModel productListModel)
        {
            MultipartFormDataContent formData=new MultipartFormDataContent();
            if(productListModel.Image!=null){
                var bytes=await File.ReadAllBytesAsync(productListModel.Image.FileName);
                ByteArrayContent byteContent=new ByteArrayContent(bytes);
                byteContent.Headers.ContentType=new MediaTypeHeaderValue(productListModel.Image.ContentType);

                formData.Add(byteContent,nameof(ProductListModel.Image),productListModel.Image.FileName);
            }
            
            formData.Add(new StringContent(productListModel.Id.ToString()),nameof(ProductListModel.Id));
            formData.Add(new StringContent(productListModel.CategoryId.ToString()),nameof(ProductListModel.CategoryId));
            formData.Add(new StringContent(productListModel.Price.ToString()),nameof(ProductListModel.Price));
            formData.Add(new StringContent(productListModel.ProductDescription),nameof(ProductListModel.ProductDescription));
            formData.Add(new StringContent(productListModel.ProductName),nameof(ProductListModel.ProductName));
            formData.Add(new StringContent(productListModel.StockQuantity.ToString()),nameof(ProductListModel.StockQuantity));

            _httpClient.DefaultRequestHeaders.Authorization=
                new AuthenticationHeaderValue("Bearer",_httpContextAccessor.HttpContext.Session.GetString("token"));

            var responseMessage=await _httpClient.PutAsync($"{productListModel.Id}",formData);
            if(responseMessage.IsSuccessStatusCode){
                return JsonConvert.DeserializeObject<ProductListModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        
        public async Task AddAsync(ProductListModel productListModel){
            MultipartFormDataContent formData=new MultipartFormDataContent();
            if(productListModel.Image!=null){
                var bytes=await System.IO.File.ReadAllBytesAsync(productListModel.Image.FileName);
                ByteArrayContent byteContent=new ByteArrayContent(bytes);
                byteContent.Headers.ContentType=new MediaTypeHeaderValue(productListModel.Image.ContentType);

                formData.Add(byteContent,nameof(ProductListModel.Image),productListModel.Image.FileName);
            }
            formData.Add(new StringContent(productListModel.Id.ToString()),nameof(ProductListModel.Id));
            formData.Add(new StringContent(productListModel.CategoryId.ToString()),nameof(ProductListModel.CategoryId));
            formData.Add(new StringContent(productListModel.ImagePath),nameof(ProductListModel.ImagePath));
            formData.Add(new StringContent(productListModel.Price.ToString()),nameof(ProductListModel.Price));
            formData.Add(new StringContent(productListModel.ProductDescription),nameof(ProductListModel.ProductDescription));
            formData.Add(new StringContent(productListModel.ProductName),nameof(ProductListModel.ProductName));
            formData.Add(new StringContent(productListModel.StockQuantity.ToString()),nameof(ProductListModel.StockQuantity));

            _httpClient.DefaultRequestHeaders.Authorization=
                new AuthenticationHeaderValue("Bearer",_httpContextAccessor.HttpContext.Session.GetString("token"));
            var responseMessage=await _httpClient.PostAsync("",formData);
            if(responseMessage.IsSuccessStatusCode){
                //do something or control
            }
            
        }
        public async Task DeleteAsync(int id){
            _httpClient.DefaultRequestHeaders.Authorization=
                new AuthenticationHeaderValue
                ("Bearer",_httpContextAccessor.HttpContext.Session.GetString("token"));

            var responseMessage=await _httpClient.DeleteAsync($"{id}");
            if(responseMessage.IsSuccessStatusCode){
                //do something
            }


        }

        public async Task<List<ProductListModel>> GetLastFiveAsync()
        {
            var responseMessage=await _httpClient.GetAsync("GetLastFiveProduct");
            if(responseMessage.IsSuccessStatusCode){
                var products=JsonConvert
                    .DeserializeObject<List<ProductListModel>>(await responseMessage.Content.ReadAsStringAsync());
                return(products);
            }
            return null;
        }

        public async Task<List<ProductListModel>> GetProductsBySearchAsync(string searchString)
        {
            var responseMessage=await _httpClient.GetAsync($"GetProductsWithSearch/{searchString}");
            if(responseMessage.IsSuccessStatusCode){
                var searchedProducts=JsonConvert.DeserializeObject<List<ProductListModel>>
                    (await responseMessage.Content.ReadAsStringAsync());
                return searchedProducts;    
            }
            else
                return null;
        }

      
    }
}