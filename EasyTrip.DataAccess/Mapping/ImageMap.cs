using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.DataAccess.Mapping
{
    public class ImageMap : BaseMap<Image>
    {
        public ImageMap()
        {
            Property(x => x.PhotoUrl).HasMaxLength(300);

            HasRequired(x => x.Blog)
                .WithMany(x => x.Images)
                .HasForeignKey(x=>x.BlogId)
                .WillCascadeOnDelete(false);
        }
    }
}
