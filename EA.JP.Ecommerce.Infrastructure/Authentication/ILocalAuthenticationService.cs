using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.JP.Ecommerce.Infrastructure.Authentication
{
    public interface ILocalAuthenticationService
    {
        User Login(string email, string password);
        User RegisterUser(string email, string password);
    }

}
