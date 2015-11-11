using EA.WebApi.Common;
using EA.WebApi.Common.logging;
using EA.WebApi.Common.Security;
using EA.WebApi.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;

namespace EA.WebApi.Web.Api.Security
{
    public class TaskDataSecurityMessageHandler : DelegatingHandler
    {
        private readonly ILog _log;
        private readonly IUserSession _userSession;
        public TaskDataSecurityMessageHandler(ILogManager logManager, IUserSession userSession)
        {
            _userSession = userSession;
            _log = logManager.GetLog(typeof(TaskDataSecurityMessageHandler));
        }
        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (CanHandleResponse(response))
            {
                ApplySecurityToResponseData((ObjectContent)response.Content);
            }
            return response;
        }
        public bool CanHandleResponse(HttpResponseMessage response)
        {
            var objectContent = response.Content as ObjectContent;
            var canHandleResponse = objectContent != null && objectContent.ObjectType == typeof(Task);
            return canHandleResponse;
        }
        public void ApplySecurityToResponseData(ObjectContent responseObjectContent)
        {
            var removeSensitiveData = !_userSession.IsInRole(Constants.RoleNames.SeniorWorker);
            if (removeSensitiveData)
            {
                _log.DebugFormat("Applying security data masking for user {0}", _userSession.Username);
            }
((Task) responseObjectContent.Value).SetShouldSerializeAssignees(!removeSensitiveData);
        }

    }
}