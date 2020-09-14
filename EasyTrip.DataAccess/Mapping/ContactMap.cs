using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.DataAccess.Mapping
{
    class ContactMap : BaseMap<Contact>
    {
        public ContactMap()
        {
            Property(x => x.Email).HasMaxLength(150);
            Property(x => x.FullName).HasMaxLength(50);
            Property(x => x.Message).HasMaxLength(400);
        }
    }
}
