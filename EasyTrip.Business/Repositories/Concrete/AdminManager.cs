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
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal adminDal;
        public AdminManager(IAdminDal _adminDal)
        {
            adminDal = _adminDal;
        }
        public bool Delete(Admin model)
        {
            try
            {
                return adminDal.Delete(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Admin Get(Expression<Func<Admin, bool>> filter, params string[] includeList)
        {
            try
            {
                return adminDal.Get(filter, includeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Admin> GetList(Expression<Func<Admin, bool>> filter = null, params string[] includeList)
        {
            try
            {
                return adminDal.GetList(filter, includeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Admin model)
        {
            try
            {
                return adminDal.Insert(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Admin model)
        {
            try
            {
                return adminDal.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
