using EasyTrip.Business.Repositories.Abstract;
using EasyTrip.DataAccess.Abstract;
using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.Business.Repositories.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal commentDal;
        public CommentManager(ICommentDal _commentDal)
        {
            commentDal = _commentDal;
        }
        public bool Delete(Comment model)
        {
            try
            {
                return commentDal.Delete(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Comment Get(Expression<Func<Comment, bool>> filter, params string[] includeList)
        {
            try
            {
                return commentDal.Get(filter, includeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Comment> GetList(Expression<Func<Comment, bool>> filter = null, params string[] includeList)
        {
            try
            {
                return commentDal.GetList(filter, includeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Comment model)
        {
            try
            {
                return commentDal.Insert(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Comment model)
        {
            try
            {
                return commentDal.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
