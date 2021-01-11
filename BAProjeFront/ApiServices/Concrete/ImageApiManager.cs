using System;
using System.Net.Http;
using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;

namespace BAProjeFront.ApiServices.Concrete{
    public class ImageApiManager:IimageApiService{
        private readonly HttpClient _httpClient;
        public ImageApiManager(HttpClient httpClient)
        {
            _httpClient=httpClient;
            _httpClient.BaseAddress=new System.Uri("http://localhost:51061/api/images/");
        }
        public async Task<string> GetProductImageById(int id){
            var responseMessage=await _httpClient.GetAsync($"GetProductImageById/{id}");

            if(responseMessage.IsSuccessStatusCode){
                var bytes=await responseMessage.Content.ReadAsByteArrayAsync();
                return $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }return null;
        }
        

    }
}