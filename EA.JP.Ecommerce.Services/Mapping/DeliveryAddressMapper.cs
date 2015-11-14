using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Model.Customers;
using EA.JP.Ecommerce.Services.ViewModels;
using AutoMapper;

namespace EA.JP.Ecommerce.Services.Mapping
{
    public static class DeliveryAddressMapper
    {
        public static DeliveryAddressView ConvertToDeliveryAddressView(
                                               this DeliveryAddress deliveryAddress)
        {
            return Mapper.Map<DeliveryAddress,
                              DeliveryAddressView>(deliveryAddress);
        }
    }

}
