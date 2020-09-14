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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal blogDal;
        public BlogManager(IBlogDal _blogDal)
        {
            blogDal = _blogDal;
        }
        public bool Delete(Blog model)
        {
            try
            {
                return blogDal.Delete(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Blog Get(Expression<Func<Blog, bool>> filter, params string[] includeList)
        {
            try
            {
                return blogDal.Get(filter, includeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Blog> GetList(Expression<Func<Blog, bool>> filter = null, params string[] includeList)
        {
            try
            {
                return blogDal.GetList(filter, includeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Blog model)
        {
            try
            {
                return blogDal.Insert(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Blog model)
        {
            try
            {
                return blogDal.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
