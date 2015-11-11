using EA.WebApi.Common;
using EA.WebApi.Model;
using EA.WebApi.Web.Api.MaintenanceProcessing;
using EA.WebApi.Web.Common;
using EA.WebApi.Web.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EA.WebApi.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("tasks")]
    [UnitOfWorkActionFilter]
    [Authorize(Roles = Constants.RoleNames.SeniorWorker)]
    public class TaskUsersController : ApiController
    {
        private readonly ITaskUsersMaintenanceProcessor _taskUsersMaintenanceProcessor;
        public TaskUsersController(ITaskUsersMaintenanceProcessor taskUsersMaintenanceProcessor)
        {
            _taskUsersMaintenanceProcessor = taskUsersMaintenanceProcessor;
        }
        [Route("{taskId:long}/users", Name = "ReplaceTaskUsersRoute")]
        [HttpPut]
        public Task ReplaceTaskUsers(long taskId, [FromBody] IEnumerable<long> userIds)
        {
            var task = _taskUsersMaintenanceProcessor.ReplaceTaskUsers(taskId, userIds);
            return task;
        }

        [Route("{taskId:long}/users", Name = "DeleteTaskUsersRoute")]
        [HttpDelete]
        public Task DeleteTaskUsers(long taskId)
        {
            var task = _taskUsersMaintenanceProcessor.DeleteTaskUsers(taskId);
            return task;
        }
        [Route("{taskId:long}/users/{userId:long}", Name = "AddTaskUserRoute")]
        [HttpPut]
        public Task AddTaskUser(long taskId, long userId)
        {
            var task = _taskUsersMaintenanceProcessor.AddTaskUser(taskId, userId);
            return task;
        }

        [Route("{taskId:long}/users/{userId:long}", Name = "DeleteTaskUserRoute")]
        [HttpDelete]
        public Task DeleteTaskUser(long taskId, long userId)
        {
            var task = _taskUsersMaintenanceProcessor.DeleteTaskUser(taskId, userId);
            return task;
        }


    }
}
