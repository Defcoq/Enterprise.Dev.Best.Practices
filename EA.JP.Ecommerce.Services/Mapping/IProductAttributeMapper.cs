using System;
using System.Collections.Generic;
using EA.JP.Ecommerce.Model.Products;
using EA.JP.Ecommerce.Services.ViewModels;
using AutoMapper;

namespace EA.JP.Ecommerce.Services.Mapping
{
    public static class IProductAttributeMapper
    {
        public static RefinementGroup ConvertToRefinementGroup(
                                this IEnumerable<IProductAttribute> productAttributes,
                                RefinementGroupings refinementGroupType)
        {
            RefinementGroup refinementGroup = new RefinementGroup()
            {
                Name = refinementGroupType.ToString(),
                GroupId = (int)refinementGroupType
            };

            refinementGroup.Refinements =
                      Mapper.Map<IEnumerable<IProductAttribute>, IEnumerable<Refinement>>
                                                                     (productAttributes);

            return refinementGroup;
        }
    }

}
