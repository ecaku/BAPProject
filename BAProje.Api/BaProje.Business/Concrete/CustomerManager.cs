 using BaProje.Business.Interfaces;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.Business.Concrete
{
    public class CustomerManager:GenericManager<Customer>,ICustomerService
    {
        private readonly IGenericDal<Customer> _genericDal;
        private readonly ICustomerDal _customerDal;
        public CustomerManager(IGenericDal<Customer> genericDal,ICustomerDal customerDal):base(genericDal)
        {
            _genericDal = genericDal;
            _customerDal = customerDal;
            
        }

     

        public async Task<Customer> CheckCustomerAsync(CustomerLoginDto customerLoginDto)
        {
            return await _genericDal.GetAsync
                (I => I.CustomerName == customerLoginDto.CustomerName && I.Password == customerLoginDto.Password);
        }

        public async Task<Customer> FindByNameAsync(string userName)
        {
            return await _customerDal.FindByNameAsync(userName);
            
        }

        public async  Task<List<Customer>> GetCustomersWithCart()
        {
            var customers = await _customerDal.GetCustomersWithCard();
            return customers;
        }

        public async Task<Customer> GetCustomersWithCart(int id)
        {
            var customer = await _customerDal.GetCustomersWithCard(id);
            return customer;
        }

        
    }
}
