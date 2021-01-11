using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;
using BAProjeFront.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BAProjeFront.ApiServices.Concrete{
    public class AuthManager:IAuthService{
        private readonly HttpClient _httpClient;
        
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthManager(IHttpContextAccessor httpContextAccessor,HttpClient httpClient)
        {
            _httpContextAccessor=httpContextAccessor;
            _httpClient=httpClient;
            _httpClient.BaseAddress=new System.Uri("http://localhost:51061/api/Auth/");
        }
        public async Task<bool> Signin(LoginCustomerModel loginCustomerModel ){

            var jsonData=JsonConvert.SerializeObject(loginCustomerModel);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage=await _httpClient.PostAsync("Signin",stringContent);

            if(responseMessage.IsSuccessStatusCode){

                var accessToken=JsonConvert.DeserializeObject<AccessToken>(await responseMessage.Content.ReadAsStringAsync());
                _httpContextAccessor.HttpContext.Session.SetString("token",accessToken.Token);
                return true;
            }
            return false;
            
        }

        public async Task<bool> Signup(SignupCustomerModel signupCustomerModel)
        {
            var jsonData=JsonConvert.SerializeObject(signupCustomerModel);
            var stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage=await _httpClient.PostAsync("Register",stringContent);

            if(responseMessage.IsSuccessStatusCode){
                return true;
            }
            return false;
            
        }
        public bool LogOut(){
            try{
                _httpContextAccessor.HttpContext.Session.Clear();
            }
            catch{
                return false;
            }
            return true;
            
        }
    }
}