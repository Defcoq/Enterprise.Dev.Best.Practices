using EA.WebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.WebApi.Data.SqlServer.mappings
{
    public class StatusMap : VersionedClassMap<Status>
    {
        public StatusMap()
        {
            Id(x => x.StatusId);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Ordinal).Not.Nullable();
        }
    }

}
