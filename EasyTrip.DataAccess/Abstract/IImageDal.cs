using System;
using EasyTrip.Core.Data.EF;
using EasyTrip.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.DataAccess.Abstract
{
    public interface IImageDal : IRepository<Image>
    {
    }
}
