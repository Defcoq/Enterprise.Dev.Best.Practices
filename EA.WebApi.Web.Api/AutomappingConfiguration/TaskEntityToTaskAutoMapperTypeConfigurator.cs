using AutoMapper;
using EA.WebApi.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.AutomappingConfiguration
{
    public class TaskEntityToTaskAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.Task, EA.WebApi.Model.Task>()
            .ForMember(opt => opt.Links, x => x.Ignore())
            .ForMember(opt => opt.Assignees, x => x.ResolveUsing<TaskAssigneesResolver>());
        }
    }

}