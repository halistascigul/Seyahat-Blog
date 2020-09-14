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
    public class ImageManager : IImageService
    {
        private readonly IImageDal imageDal;
        public ImageManager(IImageDal _imageDal)
        {
            imageDal = _imageDal;
        }

        public bool Delete(Image model)
        {
            try
            {
                return imageDal.Delete(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Image Get(Expression<Func<Image, bool>> filter, params string[] includeList)
        {
            try
            {
                return imageDal.Get(filter, includeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Image> GetList(Expression<Func<Image, bool>> filter = null, params string[] includeList)
        {
            try
            {
                return imageDal.GetList(filter, includeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Image model)
        {
            try
            {
                return imageDal.Insert(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Image model)
        {
            try
            {
                return imageDal.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
