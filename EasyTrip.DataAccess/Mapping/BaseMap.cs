using EasyTrip.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.DataAccess.Mapping
{
   public class BaseMap<T> : EntityTypeConfiguration<T>
        where T: BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.Created).HasColumnType("datetime");
            Property(x => x.Updated).HasColumnType("datetime");
            HasKey(x => x.Id);
        }
    }
}
