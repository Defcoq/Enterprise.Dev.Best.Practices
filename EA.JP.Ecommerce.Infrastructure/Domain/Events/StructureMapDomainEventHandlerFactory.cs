using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace EA.JP.Ecommerce.Infrastructure.Domain.Events
{
    public class StructureMapDomainEventHandlerFactory : IDomainEventHandlerFactory
    {
        public IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>
                                              (T domainEvent) where T : IDomainEvent
        {
            return ObjectFactory.GetAllInstances<IDomainEventHandler<T>>();
        }
    }

}
