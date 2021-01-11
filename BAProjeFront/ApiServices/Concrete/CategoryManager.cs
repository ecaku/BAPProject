using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;
using BAProjeFront.Models;
using Newtonsoft.Json;

namespace BAProjeFront.ApiServices.Concrete{
    public class CategoryManager : ICategoryService
    {
        private readonly HttpClient _httpclient;
        public CategoryManager(HttpClient httpClient)
        {
            _httpclient=httpClient;
            _httpclient.BaseAddress=new System.Uri("http://localhost:51061/api/categories/");
        }
        public async Task<List<CategoryListModel>> GetAllAsync()
        {
            var responseMessage=await _httpclient.GetAsync("");
            if(responseMessage.IsSuccessStatusCode){
                return JsonConvert.DeserializeObject<List<CategoryListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}