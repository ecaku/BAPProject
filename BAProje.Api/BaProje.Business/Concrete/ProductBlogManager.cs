using BaProje.Business.Interfaces;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.Concrete
{
    public class ProductBlogManager:GenericManager<ProductBlog>,IProductBlogService
    {
        private readonly IGenericDal<ProductBlog> _genericDal;
        public ProductBlogManager(IGenericDal<ProductBlog> genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
