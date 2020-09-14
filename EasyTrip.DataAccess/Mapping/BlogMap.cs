using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.DataAccess.Mapping
{
    public class BlogMap :BaseMap<Blog>
    {
        public BlogMap()
        {
            Property(x => x.Content).HasMaxLength(2000);
            Property(x => x.Title).HasMaxLength(50);

            HasMany(x => x.Images)
                .WithRequired(x => x.Blog)
                .HasForeignKey(x => x.BlogId)
                .WillCascadeOnDelete(false);
        }
    }
}
