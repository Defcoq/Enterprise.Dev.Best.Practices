using AutoMapper;
using EA.WebApi.Common.TypeMapping;
using EA.WebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.AutomappingConfiguration
{
    public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<User, Model.User>()
            .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }

}