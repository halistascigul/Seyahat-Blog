using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.Core.BaseModel
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
