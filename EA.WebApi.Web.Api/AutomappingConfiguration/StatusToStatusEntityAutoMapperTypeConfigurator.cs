using AutoMapper;
using EA.WebApi.Common.TypeMapping;
using EA.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.AutomappingConfiguration
{
    public class StatusToStatusEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Status, Data.Entities.Status>()
            .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }

}