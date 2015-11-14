using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using EA.JP.Ecommerce.Controllers.ActionArguments;
using EA.JP.Ecommerce.Infrastructure.Authentication;
using EA.JP.Ecommerce.Services.Interfaces;

namespace EA.JP.Ecommerce.Controllers.Controllers
{
    public abstract class BaseAccountController : Controller
    {
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly ICustomerService _customerService;
        protected readonly IExternalAuthenticationService
                                              _externalAuthenticationService;
        protected readonly IFormsAuthentication _formsAuthentication;
        protected readonly IActionArguments _actionArguments;

        public BaseAccountController(
                            ILocalAuthenticationService authenticationService,
                            ICustomerService customerService,
                            IExternalAuthenticationService
                                                externalAuthenticationService,
                            IFormsAuthentication formsAuthentication,
                            IActionArguments actionArguments)
        {
            _authenticationService = authenticationService;
            _customerService = customerService;
            _externalAuthenticationService = externalAuthenticationService;
            _formsAuthentication = formsAuthentication;
            _actionArguments = actionArguments;
        }

        public ActionResult RedirectBasedOn(string returnUrl)
        {
            if (returnUrl == ActionArgumentKey.GoToCheckout.ToString())
                return RedirectToAction("Checkout", "Checkout");
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionArgumentKey GetReturnActionFrom(string returnUrl)
        {
            if (!String.IsNullOrEmpty(returnUrl) &&
                                    returnUrl.ToLower().Contains("checkout"))
                return ActionArgumentKey.GoToCheckout;
            else
                return ActionArgumentKey.GoToAccount;
        }
    }     

}
