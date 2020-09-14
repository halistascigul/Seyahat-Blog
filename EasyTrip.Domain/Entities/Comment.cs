using EasyTrip.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string UserFullName { get; set; }
        public string Mail { get; set; }
        public string Text { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
