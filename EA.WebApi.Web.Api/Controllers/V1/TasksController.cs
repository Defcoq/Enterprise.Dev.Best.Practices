using EA.WebApi.Common;
using EA.WebApi.Data.Entities;
using EA.WebApi.Model.InquiryProcessing;
using EA.WebApi.Web.Api.MaintenanceProcessing;
using EA.WebApi.Web.Api.Models;
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
    [Authorize(Roles = Constants.RoleNames.Manager)]
    [Authorize(Roles = Constants.RoleNames.JuniorWorker)]
    public class TasksController : ApiController
    {
        private readonly IAddTaskMaintenanceProcessor _addTaskMaintenanceProcessor;
        private readonly ITaskByIdInquiryProcessor _taskByIdInquiryProcessor;
        private readonly IUpdateTaskMaintenanceProcessor _updateTaskMaintenanceProcessor;

       
        public TasksController(IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor,
        ITaskByIdInquiryProcessor taskByIdInquiryProcessor, IUpdateTaskMaintenanceProcessor updateTaskMaintenanceProcessor)
        {
            _addTaskMaintenanceProcessor = addTaskMaintenanceProcessor;
            _taskByIdInquiryProcessor = taskByIdInquiryProcessor;
            _updateTaskMaintenanceProcessor = updateTaskMaintenanceProcessor;

        }

        [Route("", Name = "AddTaskRoute")]
        [HttpPost]
        public IHttpActionResult AddTask(HttpRequestMessage requestMessage, NewTask newTask)
        {
            var task = _addTaskMaintenanceProcessor.AddTask(newTask);
            var result = new TaskCreatedActionResult(requestMessage, task);
            return result;

        }

        [Route("{id:long}", Name = "GetTaskRoute")]
        public EA.WebApi.Model.Task GetTask(long id)
        {
            var task = _taskByIdInquiryProcessor.GetTask(id);
            return task;
        }

        [Route("{id:long}", Name = "UpdateTaskRoute")]
        [HttpPut]
        [HttpPatch]
        [Authorize(Roles = Constants.RoleNames.SeniorWorker)]
        public Task UpdateTask(long id, [FromBody] object updatedTask)
        {
            var task = _updateTaskMaintenanceProcessor.UpdateTask(id, updatedTask);
            return task;
        }


    }
}
