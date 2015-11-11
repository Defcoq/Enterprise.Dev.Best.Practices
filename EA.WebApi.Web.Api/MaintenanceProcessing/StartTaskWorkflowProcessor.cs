using EA.WebApi.Common;
using EA.WebApi.Common.TypeMapping;
using EA.WebApi.Data.Exceptions;
using EA.WebApi.Data.QueryProcessors;
using EA.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.MaintenanceProcessing
{
    public class StartTaskWorkflowProcessor : IStartTaskWorkflowProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _taskByIdQueryProcessor;
        private readonly IDateTime _dateTime;
        private readonly IUpdateTaskStatusQueryProcessor _updateTaskStatusQueryProcessor;
        public StartTaskWorkflowProcessor(ITaskByIdQueryProcessor taskByIdQueryProcessor,
        IUpdateTaskStatusQueryProcessor updateTaskStatusQueryProcessor, IAutoMapper autoMapper,IDateTime dateTime)
        {
            _taskByIdQueryProcessor = taskByIdQueryProcessor;
            _updateTaskStatusQueryProcessor = updateTaskStatusQueryProcessor;
            _autoMapper = autoMapper;
            _dateTime = dateTime;
        }
        public Task StartTask(long taskId)
        {
            var taskEntity = _taskByIdQueryProcessor.GetTask(taskId);
            if (taskEntity == null)
            {
                throw new RootObjectNotFoundException("Task not found");
            }
            // Simulate some workflow logic...
            if (taskEntity.Status.Name != "Not Started")
            {
                throw new BusinessRuleViolationException("Incorrect task status. Expected status of 'Not Started'.");
            }
            taskEntity.StartDate = _dateTime.UtcNow;
            _updateTaskStatusQueryProcessor.UpdateTaskStatus(taskEntity, "In Progress");
            var task = _autoMapper.Map<Task>(taskEntity);
            return task;
        }

    }
}