using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.JP.Ecommerce.Infrastructure.Domain.Events;

namespace EA.JP.Ecommerce.Model.Orders.Events
{
    public class OrderSubmittedEvent : IDomainEvent
    {
        public Order Order { get; set; }
    }

}
