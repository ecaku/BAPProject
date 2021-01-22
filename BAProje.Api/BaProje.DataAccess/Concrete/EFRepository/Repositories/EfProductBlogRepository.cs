using BaProje.DataAccess.Concrete.EFRepository.Context;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.DataAccess.Concrete.EFRepository.Repositories
{
    public class EfProductBlogRepository:EfGenericRepository<ProductBlog>,IProductBlogDal
    {
        private readonly BAP_Context _context;
        public EfProductBlogRepository(BAP_Context context) : base(context)
        {
            _context = context;
        }
    }
}
