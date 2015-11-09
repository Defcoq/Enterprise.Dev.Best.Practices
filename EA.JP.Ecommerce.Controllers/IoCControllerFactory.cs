using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace EA.JP.Ecommerce.Controllers
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}
