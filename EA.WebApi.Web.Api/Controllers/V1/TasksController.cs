using EA.WebApi.Common;
using EA.WebApi.Data.Entities;
using EA.WebApi.Data.QueryProcessors;
using EA.WebApi.Model;
using EA.WebApi.Model.InquiryProcessing;
using EA.WebApi.Web.Api.InquiryProcessing;
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
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        private readonly IAllTasksInquiryProcessor _allTasksInquiryProcessor;



        public TasksController(IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor,
        ITaskByIdInquiryProcessor taskByIdInquiryProcessor, IUpdateTaskMaintenanceProcessor updateTaskMaintenanceProcessor, IPagedDataRequestFactory pagedDataRequestFactory,
IAllTasksInquiryProcessor allTasksInquiryProcessor
)
        {
            _addTaskMaintenanceProcessor = addTaskMaintenanceProcessor;
            _taskByIdInquiryProcessor = taskByIdInquiryProcessor;
            _updateTaskMaintenanceProcessor = updateTaskMaintenanceProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _allTasksInquiryProcessor = allTasksInquiryProcessor;


        }

        [Route("", Name = "GetTasksRoute")]
        public PagedDataInquiryResponse<EA.WebApi.Model.Task> GetTasks(HttpRequestMessage requestMessage)
        {
            var request = _pagedDataRequestFactory.Create(requestMessage.RequestUri);
            var tasks = _allTasksInquiryProcessor.GetTasks(request);
            return tasks;
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
        public EA.WebApi.Model.Task UpdateTask(long id, [FromBody] object updatedTask)
        {
            var task = _updateTaskMaintenanceProcessor.UpdateTask(id, updatedTask);
            return task;
        }


    }
}
