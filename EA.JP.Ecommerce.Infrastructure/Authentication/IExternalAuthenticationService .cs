using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.JP.Ecommerce.Infrastructure.Authentication
{
    public interface IExternalAuthenticationService
    {
        User GetUserDetailsFrom(string token);
    }
}
