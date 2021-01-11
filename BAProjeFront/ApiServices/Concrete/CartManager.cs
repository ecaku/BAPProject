using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;
using BAProjeFront.Extensions;
using BAProjeFront.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BAProjeFront.ApiServices.Concrete{
    public class CartManager : ICartService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        
        public CartManager(HttpClient httpClient,IHttpContextAccessor contextAccessor)
        {
            _httpClient=httpClient;
            _httpClient.BaseAddress=new System.Uri("http://localhost:51061/api/Cart/");
            _contextAccessor=contextAccessor;
        }

        public async Task<Cart> GetCartAsync(int id)
        {
           var responseMessage=await _httpClient.GetAsync($"{id}");
            if(responseMessage.IsSuccessStatusCode){
                var cart= JsonConvert.DeserializeObject<Cart>(await responseMessage.Content.ReadAsStringAsync());
                return cart;
            }
            return null;
        }
        
        public async Task<ProductOfCart> AddProductToCartAsync(int id)
        {
            var customerModel=_contextAccessor.HttpContext.Session.GetObject<CustomerViewModel>("activeUser");
            var cartId=customerModel.Cart.Id;
            var addProductModel=new AddProductModel()
            {
                ProductId=id,
                CartId=cartId
            };
            var JsonData=JsonConvert.SerializeObject(addProductModel);
            var stringContent=new StringContent(JsonData,Encoding.UTF8,"application/json");

            var token=_contextAccessor.HttpContext.Session.GetString("token");
            
            _httpClient.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",token);


            var responseMessage=await _httpClient.PostAsync("AddProductToCart",stringContent);
            
            if(responseMessage.IsSuccessStatusCode){

                var addedProduct=JsonConvert.DeserializeObject<ProductOfCart>
                    (await responseMessage.Content.ReadAsStringAsync());

                    
                return addedProduct;
            }
            else
                return null;
            
            
        }

        public async Task DeleteProductFromCartAsnc(int id)
        {
             var token=_contextAccessor.HttpContext.Session.GetString("token");
            _httpClient.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",token);
            
            var responseMessage=await _httpClient.DeleteAsync($"{id}");

            if(responseMessage.IsSuccessStatusCode){

            }
        }
    }
}