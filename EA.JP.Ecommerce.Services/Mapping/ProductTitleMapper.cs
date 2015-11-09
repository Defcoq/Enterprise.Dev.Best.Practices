using System.Collections.Generic;
using EA.JP.Ecommerce.Model.Products;
using EA.JP.Ecommerce.Services.ViewModels;
using AutoMapper;

namespace EA.JP.Ecommerce.Services.Mapping
{
    public static class ProductTitleMapper
    {
        public static IEnumerable<ProductSummaryView> ConvertToProductViews(
                                                this IEnumerable<ProductTitle> products)
        {
            return Mapper.Map<IEnumerable<ProductTitle>,
                              IEnumerable<ProductSummaryView>>(products);
        }

        public static ProductView ConvertToProductDetailView(this ProductTitle product)
        {
            return Mapper.Map<ProductTitle, ProductView>(product);
        }
    }
}
