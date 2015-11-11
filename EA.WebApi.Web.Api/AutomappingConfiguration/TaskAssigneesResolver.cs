using AutoMapper;
using EA.WebApi.Common.TypeMapping;
using EA.WebApi.Data.Entities;
using EA.WebApi.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.AutomappingConfiguration
{
    public class TaskAssigneesResolver : ValueResolver<Task, List<User>>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }
        protected override List<User> ResolveCore(Task source)
        {
            return source.Users.Select(x => AutoMapper.Map<User>(x)).ToList();
        }
    }

}