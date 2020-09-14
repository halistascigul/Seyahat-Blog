using EasyTrip.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.Core.Data.EF
{
    public class Repository<T, TContext> : IRepository<T>
        where T : BaseEntity
        where TContext : DbContext
    {
        protected TContext ctx;
        public Repository(TContext context)
        {
            ctx = context;
        }
        public bool Delete(T model)
        {
            try
            {
                model.IsDeleted = true;
                model.IsActive = false;
                return ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Get(Expression<Func<T, bool>> filter, params string[] includeList)
        {
            IQueryable<T> query = null;
            try
            {
                query = ctx.Set<T>();
                if (includeList != null)
                {
                    foreach (var item in includeList)
                    {
                        query = query.Include(item);

                    }
                }
                return query.FirstOrDefault(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null, params string[] includeList)
        {
            IQueryable<T> query = null;
            try
            {
                if (filter != null)
                {
                    query = ctx.Set<T>().Where(filter);
                }
                else
                {
                    query = ctx.Set<T>();
                }
                if (includeList != null)
                {
                    foreach (var item in includeList)
                    {
                        query = query.Include(item);
                    }
                }
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(T model)
        {
            try
            {
                ctx.Set<T>().Add(model);
                return ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(T model)
        {
            try
            {
                model.Updated = DateTime.Now;
                ctx.Set<T>().AddOrUpdate(x => x.Id, model);
                return ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
