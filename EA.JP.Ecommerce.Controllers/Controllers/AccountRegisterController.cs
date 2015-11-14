using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using EA.JP.Ecommerce.Controllers.ActionArguments;
using EA.JP.Ecommerce.Controllers.ViewModels.Account;
using EA.JP.Ecommerce.Infrastructure.Authentication;
using EA.JP.Ecommerce.Services.Implementations;
using EA.JP.Ecommerce.Services.Interfaces;
using EA.JP.Ecommerce.Services.Messaging.CustomerService;

namespace EA.JP.Ecommerce.Controllers.Controllers
{
    public class AccountRegisterController : BaseAccountController
    {
        public AccountRegisterController(
                            ILocalAuthenticationService authenticationService,
                            ICustomerService customerService,
                            IExternalAuthenticationService
                                                externalAuthenticationService,
                            IFormsAuthentication formsAuthentication,
                            IActionArguments actionArguments)
            : base(authenticationService, customerService,
                   externalAuthenticationService,
                   formsAuthentication, actionArguments)
        {
        }

        public ActionResult Register()
        {
            AccountView accountView = InitializeAccountViewWithIssue(false,
                                                                     string.Empty);

            return View(accountView);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(FormCollection collection)
        {
            User user;

            string password = collection[FormDataKeys.Password.ToString()];
            string email = collection[FormDataKeys.Email.ToString()];
            string firstName = collection[FormDataKeys.FirstName.ToString()];
            string secondName = collection[FormDataKeys.SecondName.ToString()];

            try
            {
                user = _authenticationService.RegisterUser(email, password);
            }
            catch (InvalidOperationException ex)
            {
                AccountView accountView = InitializeAccountViewWithIssue(
                                                             true,
                                                                         ex.Message);

                return View(accountView);
            }

            if (user.IsAuthenticated)
            {
                try
                {
                    CreateCustomerRequest createCustomerRequest =
                                            new CreateCustomerRequest();
                    createCustomerRequest.CustomerIdentityToken =
                                            user.AuthenticationToken;
                    createCustomerRequest.Email = email;
                    createCustomerRequest.FirstName = firstName;
                    createCustomerRequest.SecondName = secondName;

                    _formsAuthentication.SetAuthenticationToken(
                                                          user.AuthenticationToken);
                    _customerService.CreateCustomer(createCustomerRequest);

                    return RedirectToAction("Detail", "Customer");
                }
                catch (CustomerInvalidException ex)
                {
                    AccountView accountView = InitializeAccountViewWithIssue(
                                                                 true,
                                                                             ex.Message);

                    return View(accountView);
                }
            }
            else
            {
                AccountView accountView = InitializeAccountViewWithIssue(true,
                               "Sorry we could not authenticate you. " +
                               " Please try again.");

                return View(accountView);
            }
        }

        public ActionResult ReceiveTokenAndRegister(string token, string returnUrl)
        {
            User user = _externalAuthenticationService.GetUserDetailsFrom(token);

            if (user.IsAuthenticated)
            {
                _formsAuthentication.SetAuthenticationToken(
                                                         user.AuthenticationToken);

                // Register user
                CreateCustomerRequest createCustomerRequest =
                                                  new CreateCustomerRequest();
                createCustomerRequest.CustomerIdentityToken =
                                                  user.AuthenticationToken;
                createCustomerRequest.Email = user.Email;
                createCustomerRequest.FirstName = "[Please Enter]";
                createCustomerRequest.SecondName = "[Please Enter]";

                _customerService.CreateCustomer(createCustomerRequest);

                return RedirectBasedOn(returnUrl);
            }
            else
            {
                AccountView accountView = InitializeAccountViewWithIssue(true,
                                           "Sorry we could not authenticate you.");
                accountView.CallBackSettings.ReturnUrl =
                                            GetReturnActionFrom(returnUrl)
                                            .ToString(); ;

                return View("Register", accountView);
            }
        }

        private AccountView InitializeAccountViewWithIssue(bool hasIssue,
                                                           string message)
        {
            AccountView accountView = new AccountView();
            accountView.CallBackSettings.Action = "ReceiveTokenAndRegister";
            accountView.CallBackSettings.Controller = "AccountRegister";
            accountView.HasIssue = hasIssue;
            accountView.Message = message;

            string returnUrl = _actionArguments
                      .GetValueForArgument(ActionArgumentKey.ReturnUrl);
            accountView.CallBackSettings.ReturnUrl =
                       GetReturnActionFrom(returnUrl).ToString();

            return accountView;
        }
    }

}
