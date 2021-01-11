using BaProje.DataAccess.Concrete.EFRepository.Context;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.DataAccess.Concrete.EFRepository.Repositories
{
    public class EfCustomerRepository:EfGenericRepository<Customer>,ICustomerDal
    {
        public async Task<List<Customer>> GetCustomersWithCard()
        {
            var context = new BAP_Context();
            var customers= await context.Customer.Include(I => I.Cart).ThenInclude(I=>I.ProductOfCart).ToListAsync();
            return customers;
        }
        public async Task<Customer> GetCustomersWithCard(int id)
        {
            var context = new BAP_Context();
            var customer = await context.Customer.Where(I => I.Id == id)
                .Include(I => I.Cart)
                .ThenInclude(I=>I.ProductOfCart)
                .FirstOrDefaultAsync();
            return customer;
        }
        public async Task<Customer> FindByNameAsync(string name)
        {
            var context = new BAP_Context();
            var customer = await context.Customer.Where(I => I.CustomerName == name).Include(I => I.Cart).FirstOrDefaultAsync();
            return customer;
        }
    }
}
