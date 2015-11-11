using EA.WebApi.Common.logging;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace EA.WebApi.Web.Common.ErrorHandling
{
    public class SimpleExceptionLogger : ExceptionLogger
    {
        private readonly ILog _log;
        public SimpleExceptionLogger(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof(SimpleExceptionLogger));
        }
        public override void Log(ExceptionLoggerContext context)
        {
            _log.Error("Unhandled exception", context.Exception);
        }
    }

}
