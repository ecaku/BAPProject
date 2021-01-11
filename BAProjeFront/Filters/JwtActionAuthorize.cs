using System.Net.Http;
using System.Net.Http.Headers;
using BAProjeFront.Extensions;
using BAProjeFront.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace BAProjeFront.Filters
{
    public class JwtActionAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Session.GetString("token");

            if(string.IsNullOrWhiteSpace(token)){
                context.Result=new RedirectToActionResult("Signin","Account",new{@area=""});
            }
            else{
                using var httpClient=new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",token);
                var responseMessage=httpClient.GetAsync("http://localhost:51061/api/Auth/ActiveUser").Result;
                if(responseMessage.IsSuccessStatusCode){
                    var activeUser=JsonConvert.DeserializeObject<CustomerViewModel>(responseMessage.Content.ReadAsStringAsync().Result);

                    context.HttpContext.Session.SetObject("activeUser",activeUser);
                    context.HttpContext.Session.SetObject("Cart",activeUser.Cart);
                    context.HttpContext.Session.SetString("userName",activeUser.CustomerName);

                    if(activeUser.CustomerName=="admin")
                        context.Result=new RedirectToActionResult("index","home",new{@area="Admin"});
                    
                }
                else{
                    context.Result=new RedirectToActionResult("Signin","Account",new{@area=""});
                }
            }
        }
    }
}