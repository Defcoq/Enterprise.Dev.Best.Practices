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
    public class CompleteTaskWorkflowProcessor : ICompleteTaskWorkflowProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _taskByIdQueryProcessor;
        private readonly IDateTime _dateTime;
        private readonly IUpdateTaskStatusQueryProcessor _updateTaskStatusQueryProcessor;
        public CompleteTaskWorkflowProcessor(ITaskByIdQueryProcessor taskByIdQueryProcessor,
        IUpdateTaskStatusQueryProcessor updateTaskStatusQueryProcessor, IAutoMapper autoMapper,
        IDateTime dateTime)
        {
            _taskByIdQueryProcessor = taskByIdQueryProcessor;
            _updateTaskStatusQueryProcessor = updateTaskStatusQueryProcessor;
            _autoMapper = autoMapper;
            _dateTime = dateTime;
        }
        public Task CompleteTask(long taskId)
        {
            var taskEntity = _taskByIdQueryProcessor.GetTask(taskId);
            if (taskEntity == null)
            {
                throw new RootObjectNotFoundException("Task not found");
            }
            // Simulate some workflow logic...
            if (taskEntity.Status.Name != "In Progress")
            {
                throw new BusinessRuleViolationException("Incorrect task status. Expected status of 'In Progress'.");
            }
            taskEntity.CompletedDate = _dateTime.UtcNow;
            _updateTaskStatusQueryProcessor.UpdateTaskStatus(taskEntity, "Completed");
            var task = _autoMapper.Map<Task>(taskEntity);
            return task;
        }

    }
}