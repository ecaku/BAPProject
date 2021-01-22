using BaProje.DataAccess.Concrete.EFRepository.Context;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.DataAccess.Concrete.EFRepository.Repositories
{
    public class EfCommentRepository:EfGenericRepository<Comment>,ICommentDal
    {
        private readonly BAP_Context _context;
        public EfCommentRepository(BAP_Context context) : base(context)
        {
            _context = context;
        }
    }
}
