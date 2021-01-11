using System.Net.Http;
using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;
using BAProjeFront.Extensions;
using BAProjeFront.Filters;
using BAProjeFront.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.Controllers{
    [Route("[controller]")]
    public class AccountController:Controller{

        private readonly IAuthService _authService;
        private readonly ICustomerService _customerService;
        

        public AccountController(IAuthService authService,ICustomerService customerService)
        {
            _authService=authService;
            _customerService=customerService;
            
        }
        [HttpGet("[action]")]
        public IActionResult Signin(){
            var activeUser=HttpContext.Session.GetObject<CustomerViewModel>("activeUser");
            if(activeUser!=null){
                return RedirectToAction("accountInfo");
            }
            return View();
        }
        [HttpGet("[action]")]
        public IActionResult Signup(){
            return View();
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Signin(AccountInfoViewModel accountInfo){

            

            if(await _authService.Signin(accountInfo.loginCustomer)){
                return RedirectToAction("index","home",new {@area="Admin"});
            }

            ViewBag.statusMessage="Alanları Doğru Doldurduğunuzdan Emin misiniz?";
            return View("signin");
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Signup(AccountInfoViewModel accountInfo){
            if(await _authService.Signup(accountInfo.signupCustomer)){
                ViewBag.statusMessage="Başarılı Şekilede Kaydınız Yapılmıştır";
                return RedirectToAction("signin");
            }
            ViewBag.statusMessage="Alanları Doğru Doldurduğunuzdan Emin misiniz?";
            return View("signin");
        }
        [JwtActionAuthorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> AccountInfo(){
            
            var activeUser=HttpContext.Session.GetObject<CustomerViewModel>("activeUser");
            var customer=await _customerService.GetCustomerAsync(activeUser.Id);
            return View(customer);
        }
        [HttpGet("[action]")]
        public IActionResult LogOut(){
            var activeUser=HttpContext.Session.GetObject<CustomerViewModel>("activeUser");
            if(activeUser!=null){
                HttpContext.Session.Clear();
                return RedirectToAction("accountInfo");
                
            }
            else
                return RedirectToAction("signin","account",new {@area=""});

           
                
            
        }
        
        
    }
}