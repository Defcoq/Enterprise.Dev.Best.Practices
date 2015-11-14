using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Model.Shipping;
using EA.JP.Ecommerce.Services.ViewModels;
using AutoMapper;

namespace EA.JP.Ecommerce.Services.Mapping
{
    public static class DeliveryOptionMapper
    {
        public static IEnumerable<DeliveryOptionView> ConvertToDeliveryOptionViews
                                     (this IEnumerable<DeliveryOption> deliveryOptions)
        {
            return Mapper.Map<IEnumerable<DeliveryOption>,
                              IEnumerable<DeliveryOptionView>>(deliveryOptions);
        }
    }

}
