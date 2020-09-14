using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.DataAccess.Mapping
{
    public class AdminMap : BaseMap<Admin>
    {
        public AdminMap()
        {
            Property(x => x.AdminName).HasMaxLength(50);
            Property(x => x.Password).HasMaxLength(6);
        }
    }
}
