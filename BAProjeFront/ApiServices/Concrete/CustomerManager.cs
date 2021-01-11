using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;
using BAProjeFront.Models;
using Newtonsoft.Json;

namespace BAProjeFront.ApiServices.Concrete{
    public class CustomerManager : ICustomerService
    {
        private readonly HttpClient _httpClient;
        public CustomerManager(HttpClient httpClient)
        {
            _httpClient=httpClient;
            _httpClient.BaseAddress=new System.Uri("http://localhost:51061/api/Auth/");
        }

        public async Task<List<CustomerViewModel>> GetAllCustomersAsync()
        {
            var responseMessage=await _httpClient.GetAsync("GetAllCustomers");
            if(responseMessage.IsSuccessStatusCode){
                return JsonConvert.DeserializeObject<List<CustomerViewModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            else{
                return null;
            }
            
        }

        public async  Task<CustomerViewModel> GetCustomerAsync(int id)
        {
             var responseMessage=await _httpClient.GetAsync($"GetCustomer/{id}");
            if(responseMessage.IsSuccessStatusCode){
                return JsonConvert.DeserializeObject<CustomerViewModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            else
                return null;
        }

        
    }
}