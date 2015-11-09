using System;
using System.Collections.Generic;
using EA.JP.Ecommerce.Model.Categories;
using EA.JP.Ecommerce.Services.ViewModels;
using AutoMapper;

namespace EA.JP.Ecommerce.Services.Mapping
{
    public static class CategoryMapper
    {
        public static IEnumerable<CategoryView> ConvertToCategoryViews(
                                                this IEnumerable<Category> categories)
        {
            return Mapper.Map<IEnumerable<Category>,
                              IEnumerable<CategoryView>>(categories);
        }
    }

}
