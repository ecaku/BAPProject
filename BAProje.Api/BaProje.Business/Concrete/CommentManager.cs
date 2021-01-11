using BaProje.Business.Interfaces;
using BaProje.DataAccess.Interfaces;
using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.Concrete
{
    public class CommentManager:GenericManager<Comment>,ICommentService
    {
        private readonly IGenericDal<Comment> _genericDal;
        public CommentManager(IGenericDal<Comment> genericDal):base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
