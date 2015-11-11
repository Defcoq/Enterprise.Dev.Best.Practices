using EA.WebApi.Common;
using EA.WebApi.Model;
using EA.WebApi.Web.Api.MaintenanceProcessing;
using EA.WebApi.Web.Common;
using EA.WebApi.Web.Common.Routing;
using EA.WebApi.Web.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EA.WebApi.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("")]
    [UnitOfWorkActionFilter]
    [Authorize(Roles = Constants.RoleNames.SeniorWorker)]
    //example header = Authorization: Basic YmhvZ2c6aWdub3JlZA==
    public class TaskWorkflowController : ApiController
    {
        private readonly IStartTaskWorkflowProcessor _startTaskWorkflowProcessor;

        private readonly ICompleteTaskWorkflowProcessor _completeTaskWorkflowProcessor;
        private readonly IReactivateTaskWorkflowProcessor _reactivateTaskWorkflowProcessor;
        public TaskWorkflowController(IStartTaskWorkflowProcessor startTaskWorkflowProcessor,
        ICompleteTaskWorkflowProcessor completeTaskWorkflowProcessor,
        IReactivateTaskWorkflowProcessor reactivateTaskWorkflowProcessor)
        {
            _startTaskWorkflowProcessor = startTaskWorkflowProcessor;
            _completeTaskWorkflowProcessor = completeTaskWorkflowProcessor;
            _reactivateTaskWorkflowProcessor = reactivateTaskWorkflowProcessor;
        }

        [HttpPost]
        [Route("tasks/{taskId:long}/activations", Name = "StartTaskRoute")]
        public Task StartTask(long taskId)
        {
            var task = _startTaskWorkflowProcessor.StartTask(taskId);
            return task;
        }
        [HttpPost]
        [Route("tasks/{taskId:long}/completions", Name = "CompleteTaskRoute")]
        public Task CompleteTask(long taskId)
        {
            var task = _completeTaskWorkflowProcessor.CompleteTask(taskId);
            return task;
        }

        [HttpPost]
        [UserAudit]
        [Route("tasks/{taskId:long}/reactivations", Name = "ReactivateTaskRoute")]
        public Task ReactivateTask(long taskId)
        {
            var task = _reactivateTaskWorkflowProcessor.ReactivateTask(taskId);
            return task;
        }



    }
}
