
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.WebApi.Data.SqlServer.mappings
{
   public class TaskMap : VersionedClassMap<EA.WebApi.Data.Entities.Task>
    {
        public TaskMap()
        {
            Id(x => x.TaskId);
            Map(x => x.Subject).Not.Nullable();
            Map(x => x.StartDate).Nullable();
            Map(x => x.DueDate).Nullable();
            Map(x => x.CompletedDate).Nullable();
            Map(x => x.CreatedDate).Not.Nullable();
            References(x => x.Status, "StatusId");
            References(x => x.CreatedBy, "CreatedUserId");
            HasManyToMany(x => x.Users)
            .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
            .Table("TaskUser")
            .ParentKeyColumn("TaskId")
            .ChildKeyColumn("UserId");
        }


    }
}
