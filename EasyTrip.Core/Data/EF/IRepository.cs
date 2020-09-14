using EasyTrip.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.Core.Data.EF
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        bool Insert(T model);
        bool Update(T model);
        bool Delete(T model);
        T Get(Expression<Func<T, bool>> filter, params string[] includeList);
        List<T> GetList(Expression<Func<T, bool>> filter = null, params string[] includeList);
    }
}
