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
        private readonly BAP_Context _context;
        public EfCustomerRepository(BAP_Context context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Customer>> GetCustomersWithCard()
        {
            var customers= await _context.Customer.Include(I => I.Cart).ThenInclude(I=>I.ProductOfCart).ToListAsync();
            return customers;
        }
        public async Task<Customer> GetCustomersWithCard(int id)
        {
            var customer = await _context.Customer.Where(I => I.Id == id)
                .Include(I => I.Cart)
                .ThenInclude(I=>I.ProductOfCart)
                .FirstOrDefaultAsync();
            return customer;
        }
        public async Task<Customer> FindByNameAsync(string name)
        {
            var customer = await _context.Customer.Where(I => I.CustomerName == name).Include(I => I.Cart).FirstOrDefaultAsync();
            return customer;
        }
    }
}
