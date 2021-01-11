using BaProje.DataAccess.Concrete.EFRepository.Context;
using BAProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaProje.DataAccess.Interfaces
{
    public interface IProductDal:IGenericDal<Product>
    {
        Task<List<Product>> GetLastFiveAsync();
        
    }
}
