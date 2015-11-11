using EA.WebApi.Data.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.WebApi.Data.SqlServer.mappings
{
    public abstract class VersionedClassMap<T> : ClassMap<T> where T : IVersionedEntity
    {

        protected VersionedClassMap()
        {
            Version(x => x.Version)
            .Column("ts")
            .CustomSqlType("Rowversion")
            .Generated.Always()
            .UnsavedValue("null");
        }

    }

}
