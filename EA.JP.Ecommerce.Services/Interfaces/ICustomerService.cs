using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Services.Messaging.CustomerService;

namespace EA.JP.Ecommerce.Services.Interfaces
{
    public interface ICustomerService
    {
        CreateCustomerResponse CreateCustomer(CreateCustomerRequest request);
        GetCustomerResponse GetCustomer(GetCustomerRequest request);
        ModifyCustomerResponse ModifyCustomer(ModifyCustomerRequest request);

        DeliveryAddressModifyResponse ModifyDeliveryAddress(
                                                   DeliveryAddressModifyRequest request);
        DeliveryAddressAddResponse AddDeliveryAddress(
                                       DeliveryAddressAddRequest request);
    }

}
