using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.JP.Ecommerce.Services.ViewModels
{
    public class CustomerView
    {
        public string IdentityToken { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public IEnumerable<DeliveryAddressView> DeliveryAddressBook { get; set; }
    } 

}
