using EA.WebApi.Common;
using EA.WebApi.Common.TypeMapping;
using EA.WebApi.Data.QueryProcessors;
using EA.WebApi.Model;
using EA.WebApi.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace EA.WebApi.Web.Api.MaintenanceProcessing
{
    public class AddTaskMaintenanceProcessor : IAddTaskMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddTaskQueryProcessor _queryProcessor;
        public AddTaskMaintenanceProcessor(IAddTaskQueryProcessor queryProcessor,IAutoMapper autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }
        public Task AddTask(NewTask newTask)
        {
            var taskEntity = _autoMapper.Map<Data.Entities.Task>(newTask);
            _queryProcessor.AddTask(taskEntity);
            var task = _autoMapper.Map<Task>(taskEntity);
            // TODO: Implement link service
            task.AddLink(new Link
            {
                Method = HttpMethod.Get.Method,
                Href = "http://localhost:59972/api/v1/tasks/" + task.TaskId,
                Rel = Constants.CommonLinkRelValues.Self
            });
            return task;
        }

    }

}