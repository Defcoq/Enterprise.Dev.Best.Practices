using AutoMapper;
using EA.WebApi.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api
{
    public class AutoMapperConfigurator
    {
        public void Configure(IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurations)
        {
            autoMapperTypeConfigurations.ToList().ForEach(x => x.Configure());
            Mapper.AssertConfigurationIsValid();
        }

    }
}