using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.DataAccess.Mapping
{
    class CommentMap : BaseMap<Comment>
    {
        public CommentMap()
        {
            Property(x => x.Mail).HasMaxLength(100);
            Property(x => x.Text).HasMaxLength(300);
            Property(x => x.UserFullName).HasMaxLength(50);

            HasRequired(x => x.Blog)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.BlogId)
                .WillCascadeOnDelete(false);
        }
    }
}
