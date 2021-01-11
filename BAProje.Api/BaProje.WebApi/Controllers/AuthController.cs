using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaProje.Business.Interfaces;
using BaProje.Business.Tools.JWTTool;
using BaProje.WebApi.CustomFilters;
using BAProje.Entities.Concrete;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        public AuthController(ICustomerService customerService,ICartService cartService,IJwtService jwtService,IMapper mapper)
        {
            _customerService = customerService;
            _jwtService = jwtService;
            _mapper = mapper;
            
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var users = _mapper.Map<List<CustomerDto>>(await _customerService.GetCustomersWithCart());

            return Ok(users);
        }
        [HttpGet("[action]/{id}")]
        
        public async Task<IActionResult> GetCustomer(int id)
        {
            var user = _mapper.Map<CustomerDto>(await _customerService.GetCustomersWithCart(id));

            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Signin(CustomerLoginDto customerLoginDto)
        {
            
            var user=await _customerService.CheckCustomerAsync(customerLoginDto);
            if (user != null)
            {
                
                return Created("",_jwtService.GenerateJwt(user));
            }
            return BadRequest("Kullanıcı Adı Veya Şifre Hatalı");
        }
        
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _customerService.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new CustomerDto {
                CustomerName=user.CustomerName,
                Id=user.Id,
                Cart=user.Cart
                
            });
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(CustomerRegisterDto customerRegisterDto)
        {
            try
            {
                await _customerService.AddAsync(_mapper.Map<Customer>(customerRegisterDto));
                var customer = await _customerService.FindByNameAsync(customerRegisterDto.CustomerName);
                customer.Cart = new Cart()
                {
                    CustomerId = customer.Id
                };

                
                await _customerService.UpdateAsync(customer);
            }
            catch(Exception ex)
            {
                return null;
            }
            

            return Created("",customerRegisterDto);
        }
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_customerService.FindByIdAsync(id) != null)
            {
                await _customerService.RemoveAsync(new Customer { Id = id });
                return NoContent();
            }
            return BadRequest("Böyle bir kullanıcı bulunmamamktadır");
            
        }

    }
}