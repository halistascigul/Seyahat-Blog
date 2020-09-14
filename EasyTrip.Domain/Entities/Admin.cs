using EasyTrip.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.Domain.Entities
{
    public class Admin : BaseEntity
    {
        public string AdminName { get; set; }
        public string Password { get; set; }
    }
}
