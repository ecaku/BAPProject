using System.Collections.Generic;
using System.Threading.Tasks;
using BAProjeFront.ApiServices.Interfaces;
using BAProjeFront.Filters;
using BAProjeFront.Models;
using Microsoft.AspNetCore.Mvc;

namespace BAProjeFront.Areas.Admin.Controllers{
    [Area("Admin")]
    public class CustomerController:Controller{
        
        
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService=customerService;
            
        }
        [AdminAuthorize]
        [HttpGet]
        public async Task<IActionResult> GetAll(){

            var users=await _customerService.GetAllCustomersAsync();
            

            return View(users);
        }
        [AdminAuthorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id){
            var user=await _customerService.GetCustomerAsync(id);
            return View(user);
        }
    }
}