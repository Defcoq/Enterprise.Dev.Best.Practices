using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Model.Customers;
using EA.JP.Ecommerce.Services.ViewModels;
using AutoMapper;

namespace EA.JP.Ecommerce.Services.Mapping
{
    public static class CustomerMapper
    {
        public static CustomerView ConvertToCustomerDetailView(
                                              this Customer customer)
        {
            return Mapper.Map<Customer, CustomerView>(customer);
        }
    }

}
