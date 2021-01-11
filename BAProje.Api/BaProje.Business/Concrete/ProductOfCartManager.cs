using BaProje.Business.Interfaces;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.Concrete
{
    public class ProductOfCartManager:GenericManager<ProductOfCart>,IProductOfCartService
    {
        private readonly IGenericDal<ProductOfCart> _genericDal;
        public ProductOfCartManager(IGenericDal<ProductOfCart> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
