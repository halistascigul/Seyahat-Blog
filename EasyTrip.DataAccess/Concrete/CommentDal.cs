using EasyTrip.Core.Data.EF;
using EasyTrip.DataAccess.Abstract;
using EasyTrip.DataAccess.Context;
using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.DataAccess.Concrete
{
    public class CommentDal : Repository<Comment, EasyTripDbContext>, ICommentDal
    {
        private readonly EasyTripDbContext context;
        public CommentDal(EasyTripDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
