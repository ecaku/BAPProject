using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.DataAccess.Concrete.EFRepository.Repositories
{
    public class EfCommentRepository:EfGenericRepository<Comment>,ICommentDal
    {
    }
}
