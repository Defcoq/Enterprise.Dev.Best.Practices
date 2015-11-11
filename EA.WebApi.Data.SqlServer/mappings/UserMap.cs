using EA.WebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.WebApi.Data.SqlServer.mappings
{
    public class UserMap : VersionedClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserId);
            Map(x => x.Firstname).Not.Nullable();
            Map(x => x.Lastname).Not.Nullable();
            Map(x => x.Username).Not.Nullable();
        }
    }

}
