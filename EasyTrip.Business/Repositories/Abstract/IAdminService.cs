using EasyTrip.Core.Data.EF;
using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.Business.Repositories.Abstract
{
    public interface IAdminService : IRepository<Admin>
    {
    }
}
