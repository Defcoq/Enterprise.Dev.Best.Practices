using EA.WebApi.Common;
using EA.WebApi.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace EA.WebApi.Web.Common.ErrorHandling
{
    public class GlobalExceptionHandler : System.Web.Http.ExceptionHandling.ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;
            var httpException = exception as HttpException;
            if (httpException != null)
            {
                context.Result = new SimpleErrorResult(context.Request,
                (HttpStatusCode)httpException.GetHttpCode(), httpException.Message);
                return;
            }
            if (exception is RootObjectNotFoundException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.NotFound,
                exception.Message);
                return;
            }
            if (exception is ChildObjectNotFoundException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.Conflict,
                exception.Message);
                return;
            }

            if (exception is BusinessRuleViolationException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.PaymentRequired,
                exception.Message);
                return;
            }

            context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.InternalServerError,
            exception.Message);

        }
    }
    }
