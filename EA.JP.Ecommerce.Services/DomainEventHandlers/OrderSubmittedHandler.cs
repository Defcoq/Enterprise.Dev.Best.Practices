using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Infrastructure.Domain.Events;
using EA.JP.Ecommerce.Infrastructure.Email;
using EA.JP.Ecommerce.Model.Orders.Events;

namespace EA.JP.Ecommerce.Services.DomainEventHandlers
{
    public class OrderSubmittedHandler : IDomainEventHandler<OrderSubmittedEvent>
    {
        public void Handle(OrderSubmittedEvent domainEvent)
        {
            StringBuilder emailBody = new StringBuilder();
            string emailAddress = domainEvent.Order.Customer.Email;
            string emailSubject = String.Format("Agatha Order #{0}",
                                                 domainEvent.Order.Id);

            emailBody.AppendLine(String.Format("Hello {0},",
                                 domainEvent.Order.Customer.FirstName));
            emailBody.AppendLine();
            emailBody.AppendLine(
             "The following order will be packed and dispatched as soon as possible.");
            emailBody.AppendLine(domainEvent.Order.ToString());
            emailBody.AppendLine();
            emailBody.AppendLine("Thank you for your custom.");
            emailBody.AppendLine("Agatha's");

            EmailServiceFactory.GetEmailService()
             .SendMail("orders@Agatha.com", emailAddress,
                       emailSubject, emailBody.ToString());
        }
    }

}
